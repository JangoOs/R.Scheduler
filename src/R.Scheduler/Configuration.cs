﻿using R.Scheduler.Contracts;
using R.Scheduler.Contracts.Interfaces;

namespace R.Scheduler
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            PersistanceStoreType = PersistanceStoreType.InMemory;
            TablePrefix = "QRTZ_";
            InstanceName = "RScheduler";
            InstanceId = "instance_one";
            UseProperties = "true";
        }

        public PersistanceStoreType PersistanceStoreType { get; set; }
        public string ConnectionString { get; set; }
        public string TablePrefix { get; set; }
        public string InstanceName { get; set; }
        public string InstanceId { get; set; }
        public string UseProperties { get; set; }
    }
}
