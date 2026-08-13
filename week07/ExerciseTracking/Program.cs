using System;
using System.Collections.Generic;

List<Activity> activities = new List<Activity>();

activities.Add(new Running("12 Aug 2026", 30, 4.8));
activities.Add(new Cycling("12 Aug 2026", 30, 20));
activities.Add(new Swimming("12 Aug 2026", 30, 30));

foreach (Activity activity in activities)
{
    Console.WriteLine(activity.GetSummary());
}