﻿namespace Hotel_Booking_System.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public DateTime PaymentDate {  get; set; }
        public decimal Amount { get; set; }
        public PaymentMethod Method { get; set; }
        public PaymentStatus Status { get; set; }
        public int BookingId { get; set; }  
        public Booking Booking { get; set; }
    }

    public enum PaymentStatus
    {
        Pending, Paid, Failed
    }
    public enum PaymentMethod
    {
        Cash, Card, UPI, Online
    }
}
