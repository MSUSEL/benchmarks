﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Spi;

namespace Ombi.Helpers
{
    public class OmbiQuartz
    {
        protected IScheduler _scheduler { get; set; }
        
        public static IScheduler Scheduler => Instance._scheduler;

        // Singleton
        protected static OmbiQuartz _instance;

        /// <summary>
        /// Singleton
        /// </summary>
        public static OmbiQuartz Instance => _instance ?? (_instance = new OmbiQuartz());

        protected OmbiQuartz()
        {
            Init();
        }

        private async void Init()
        {
            _scheduler = await new StdSchedulerFactory().GetScheduler();
        }
        
        public IScheduler UseJobFactory(IJobFactory jobFactory)
        {
            Scheduler.JobFactory = jobFactory;
            return Scheduler;
        }

        public async Task AddJob<T>(string name, string group, string cronExpression, Dictionary<string, string> jobData = null)
            where T : IJob
        {
            var jobBuilder = JobBuilder.Create<T>()
                .WithIdentity(new JobKey(name, group));
            if (jobData != null)
            {
                foreach (var o in jobData)
                {
                    jobBuilder.UsingJobData(o.Key, o.Value);
                }
            }

            if(!cronExpression.HasValue())
            {
                jobBuilder.StoreDurably(true);
            }

            var job = jobBuilder.Build();
            if (cronExpression.HasValue())
            {
                ITrigger jobTrigger = TriggerBuilder.Create()
                    .WithIdentity(name + "Trigger", group)
                    .WithCronSchedule(cronExpression, 
                        x => x.WithMisfireHandlingInstructionFireAndProceed())
                    .ForJob(name, group)
                    .StartNow()
                    .Build();
                await Scheduler.ScheduleJob(job, jobTrigger);
            } 
            else
            {
                await Scheduler.AddJob(job, true);
            }
            
        }

        public static async Task TriggerJob(string jobName, string group)
        {
            await Scheduler.TriggerJob(new JobKey(jobName, group));
        }

        public static async Task TriggerJob(string jobName, string group, IDictionary<string, object> data)
        {
            await Scheduler.TriggerJob(new JobKey(jobName, group), new JobDataMap(data));
        }

        public static async Task Start()
        {
            await Scheduler.Start();
        }
    }
}