﻿using System.Collections.Generic;
using System.Reflection;
using System.Web.Http;
using AutoMapper;
using Common.Logging;
using Quartz;
using R.Scheduler.Contracts.Model;
using R.Scheduler.Interfaces;
using StructureMap;

namespace R.Scheduler.Controllers
{
    public class AnalyticsController : ApiController
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly IAnalytics _analytics;

        public AnalyticsController()
        {
            _analytics = ObjectFactory.GetInstance<IAnalytics>();
            Mapper.CreateMap<AuditLog, FireInstance>();
        }

        /// <summary>
        /// Get count of all the jobs
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/jobCount")]
        public int GetJobCount()
        {
            Logger.Info("Entered AnalyticsController.GetJobCount().");

            return _analytics.GetJobCount();
        }

        /// <summary>
        /// Get count of all the triggers
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/triggerCount")]
        public int GetTriggerCount()
        {
            Logger.Info("Entered AnalyticsController.GetTriggerCount().");

            return _analytics.GetTriggerCount();
        }

        /// <summary>
        /// Get executing jobs
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/firedTriggers")]
        public IList<TriggerDetails> GetFiredTriggers()
        {
            Logger.Info("Entered AnalyticsController.GetFiredTriggers().");

            IEnumerable<ITrigger> quartzFiredTriggers = _analytics.GetFiredTriggers();

            return TriggerHelper.GetTriggerDetails(quartzFiredTriggers);
        }

        /// <summary>
        /// Get executing jobs
        /// </summary>
        /// <returns></returns>
        [AcceptVerbs("GET")]
        [Route("api/erroredJobs")]
        public IList<FireInstance> GetErroredJobs(int count)
        {
            Logger.Info("Entered AnalyticsController.GetErroredJobs().");

            var erroredJobs = _analytics.GetErroredJobs(count);

            IList<FireInstance> erroredFireInstances = new List<FireInstance>();

            foreach (AuditLog erroredJob in erroredJobs)
            {
                var fi = Mapper.Map<FireInstance>(erroredJob);
                erroredFireInstances.Add(fi);
            }

            return erroredFireInstances;
        }
    }
}