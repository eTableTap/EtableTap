

//// HANGFIRE JOB IDs

/// 01 = Email automated hourly Email notifications for Bookings
/// 02 = Automatic deletion of out of date incidents



//// ----------------------- HOW TO USE HANGFIRE To the level of understanding of Hayden -----------------------\\\\
///
/// Required namespace
/// using Hangfire;
/// 
/// 
/// Schedule a recuring Job
/// RecurringJob.AddOrUpdate("jobID", () => Methodtobecalled(), Cron.The_Interval_to_be_specified);
/// 
/// when adding a recuring job, please ensure you run a stop command (below) before creating it to stop identical jobs being created.
/// also ensure there is some way of stopping the job via button click or etc
/// 
/// Stop a recuring Job
/// RecurringJob.RemoveIfExists("jobID");
/// 
/// Schedule a once off Job
/// BackgroundJob.Enqueue(() => Methodtobecalled());
/// 
/// Delayed Jobs (Once off)
/// BackgroundJob.Schedule(() => Method_To_Be_Called(), TimeSpan.TIME_SPAN_REQUIRED(Int));
/// 
/// 
///  -------- Examples from code ----------
/// Recuring Job -                 
///                RecurringJob.RemoveIfExists("01");
///                
///                RecurringJob.AddOrUpdate("01", () => emailWorker(), Cron.Hourly);
///                
///
///
/// Background task - 
///                 BackgroundJob.Enqueue(() => bookingNotify(email, phone, fName, sName, tableID, roomName));
