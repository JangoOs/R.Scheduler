﻿namespace R.Scheduler.Interfaces
{
    public interface IPersistanceStore
    {
        void InsertAuditLog(IAuditLog log);
    }
}