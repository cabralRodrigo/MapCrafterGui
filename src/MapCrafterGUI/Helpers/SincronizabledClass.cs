using Newtonsoft.Json;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MapCrafterGUI.Helpers
{
    public abstract class SynchronizableClass<T>
    {
        private readonly string SynchronizationFile;

        private bool synchronizeProperties = true;

        public SynchronizableClass(string synchonizationFile)
        {
            this.SynchronizationFile = synchonizationFile;
        }
     
        public void DisableSynchronization()
        {
            this.synchronizeProperties = false;
        }

        public void EnableSynchonization()
        {
            this.synchronizeProperties = true;
        }
        
        [OnDeserialized]
        internal void OnSaved(StreamingContext context)
        {
            this.EnableSynchonization();
        }

        [OnDeserializing]
        internal void OnSaving(StreamingContext context)
        {
            this.DisableSynchronization();
        }

        protected abstract T GetDefault();

        protected void SynchronizePropertySet<R>(ref R property, R value, [CallerMemberName]string propertyName = null)
        {
            bool isEqual = object.Equals(property, value);
            property = value;

            if (this.synchronizeProperties && !isEqual)
            {
                TraceHelper.Info(string.Format("Automatically saving the \"{0}\" property, with the value \"{1}\".", propertyName, value));
                this.Save();
            }
        }

        private T Load()
        {
            T objToLoad = default(T);

            bool success = UtilHelper.LoadFileTypeFromFile<T>(this.SynchronizationFile, out objToLoad);

            if (!success || objToLoad == null)
                objToLoad = this.GetDefault();

            return objToLoad;
        }

        private void Save()
        {
            var objSaved = this.Load();

            string jsonObjectToSave = JsonConvert.SerializeObject(this);
            string jsonObjectSaved = JsonConvert.SerializeObject(objSaved);

            if (!object.Equals(jsonObjectSaved, jsonObjectToSave))
            {
                try
                {
                    File.Delete(this.SynchronizationFile);
                    IOHelper.CreateTextFile(this.SynchronizationFile, jsonObjectToSave, true);
                }
                catch (Exception ex)
                {
                    TraceHelper.Error("Error saving the configuration file in the directory " + SynchronizationFile, ex);
                }
            }
        }
    }
}