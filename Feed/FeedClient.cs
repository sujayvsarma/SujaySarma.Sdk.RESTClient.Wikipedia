using SujaySarma.Sdk.WikipediaApi.SerializationObjects;

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace SujaySarma.Sdk.WikipediaApi.Feed
{
    /// <summary>
    /// Implements the "/feed/*" endpoints. Allows fetching feed data from Wikipedia.org
    /// </summary>
    public class FeedClient : WikipediaClient
    {

        /// <summary>
        /// Get a list of aggregated events for the provided date
        /// </summary>
        /// <param name="date">Date to get events for (full date is considered!)</param>
        /// <returns>List of corresponding events for the provided day. NULL if there was a problem.</returns>
        public FeaturedEventsOnThisDay? GetFeaturedEvents(DateTime date)
        {
            if (date > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException(nameof(date), $"'{nameof(date)}' must be in the past.");
            }

            string? responseJson = GET($"feed/featured/{date.Year}/{date.Month.ToString().PadLeft(2, '0')}/{date.Day.ToString().PadLeft(2, '0')}").Result;
            if (!string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<FeaturedEventsOnThisDay>(responseJson);
            }

            return null;
        }

        /// <summary>
        /// Get events that occured on a particular day in history
        /// </summary>
        /// <param name="typeofEvent">Type of event</param>
        /// <param name="historicalDate">The date the event occured on. Only the month and year are actually considered.</param>
        /// <returns>List of corresponding events of type for the provided day. NULL if there was a problem.</returns>
        public EventsOnThisDay? GetEvents(FeedEventType typeofEvent, DateTime historicalDate)
        {
            if (! Enum.IsDefined(typeof(FeedEventType), typeofEvent))
            {
                throw new ArgumentOutOfRangeException(nameof(typeofEvent));
            }

            if (historicalDate > DateTime.Today)
            {
                throw new ArgumentOutOfRangeException(nameof(historicalDate), $"'{nameof(historicalDate)}' must be in the past.");
            }

            string? responseJson = GET($"feed/onthisday/{Enum.GetName(typeof(FeedEventType), typeofEvent)}/{historicalDate.Month.ToString().PadLeft(2, '0')}/{historicalDate.Day.ToString().PadLeft(2, '0')}")
                                    .Result;
            if (! string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<EventsOnThisDay>(responseJson);
            }

            return null;
        }

        /// <summary>
        /// Gets announcements for display in the official Wikipedia iOS and Android apps
        /// </summary>
        /// <returns>List of announcements</returns>
        public List<Announcement>? GetAnnouncements()
        {
            string? responseJson = GET("feed/announcements").Result;
            if (! string.IsNullOrWhiteSpace(responseJson))
            {
                return JsonSerializer.Deserialize<List<Announcement>>(
                        
                        // array within a wasteful structure, go directly to it
                        responseJson.Replace("{\"announce\":", "").Replace("}", "")

                    );
            }

            return null;
        }


        /// <summary>
        /// Constructor (blank)
        /// </summary>
        public FeedClient() : base() { }
    }

    /// <summary>
    /// Type of event(s) to query for
    /// </summary>
    public enum FeedEventType
    {
        /// <summary>
        /// A list of a few selected anniversaries which occur on the provided day and month; often the entries are curated for the current year
        /// </summary>
        Selected = 0,

        /// <summary>
        /// A list of birthdays which happened on the provided day and month
        /// </summary>
        Births,

        /// <summary>
        /// A list of deaths which happened on the provided day and month
        /// </summary>
        Deaths,

        /// <summary>
        /// A list of fixed holidays celebrated on the provided day and month
        /// </summary>
        Holidays,

        /// <summary>
        /// A list of significant events which happened on the provided day and month and which are not covered by the other types yet
        /// </summary>
        Events,

        /// <summary>
        /// All events
        /// </summary>
        All
    }
}
