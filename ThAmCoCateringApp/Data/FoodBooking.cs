﻿using System.ComponentModel.DataAnnotations;

namespace ThAmCoCateringApp.Data
{
    public class FoodBooking
    {
        public int FoodBookingId { get; set; }
        public int ClientReferenceId { get; set; }
        public int NumberOfGuests { get; set; }
        public int MenuId { get; set; }

        public Menu Menu { get; set; }

    }
}
