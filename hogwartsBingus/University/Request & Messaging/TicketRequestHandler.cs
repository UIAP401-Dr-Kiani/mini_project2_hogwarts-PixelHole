using System;
using System.Collections.Generic;
using System.Management.Instrumentation;
using hogwartsBingus.Base_Classes;
using hogwartsBingus.Execptions;
using hogwartsBingus.University;
using hogwartsBingus.University.DataStorage;

namespace hogwartsBingus.DataStorage
{
    public static class TicketRequestHandler
    {
        public static List<TicketRequest> TicketRequests = new List<TicketRequest>();
        public static void RequestTicket(TicketRequest request)
        {
            try
            {
                AddTicketRequest(request);
            }
            catch (TicketAlreadyRequestedException e)
            {
                throw e;
            }
        }
        public static void AddTicketRequest(TicketRequest request)
        {
            if (TicketRequests.Contains(request)) throw new TicketAlreadyRequestedException();
            TicketRequests.Add(request);
        }
        public static void RemoveTicketRequest(TicketRequest request)
        {
            if (!TicketRequests.Contains(request)) return;
            TicketRequests.Remove(request);
        }
        public static void GrantTicketRequest(TicketRequest request)
        {
            AuthorizedPerson requester = UserManager.GetUserAtIndex(UserManager.FindWithName(request.Requester));
            requester.AddTicket(TransportManager.GenerateTicket(request.Time, request.Location, request.Destination));
            RemoveTicketRequest(request);
        }
        public static TicketRequest FindRequest(string requestText)
        {
            foreach (var request in TicketRequests)
            {
                if (request.ToString() == requestText) return request;
            }

            throw new InstanceNotFoundException();
        }

        public static void RequestSave()
        {
            SaveFileManager.SaveTicketRequests(TicketRequests);
        }
        public static void RequestLoad()
        {
            TicketRequests = SaveFileManager.LoadTicketRequests();
        }
    }
}