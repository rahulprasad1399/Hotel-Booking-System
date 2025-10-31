using Hotel_Booking_System.Data;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hotel_Booking_System.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly HotelDbContext _context;
        public PaymentService(HotelDbContext context)
        {
            _context = context;
        }
        public async Task<Payment> CreatePayment(Payment payment)
        {
            await _context.payments.AddAsync(payment);
            await _context.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment> DeletePayment(int id)
        {
            Payment paymentToDelete = await _context.payments.FirstOrDefaultAsync((payment) => payment.Id == id);
            if (paymentToDelete != null)
            {
                _context.payments.Remove(paymentToDelete);
                await _context.SaveChangesAsync();
                return paymentToDelete;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<Payment>> GetAllPayments()
        {
            List<Payment> payments = await _context.payments.ToListAsync();
            return payments;
        }

        public async Task<Payment> GetPayment(int id)
        {
            Payment payment = await _context.payments.FirstOrDefaultAsync((payment) => payment.Id == id);
            if (payment != null)
            {
                return payment;
            }
            else
            {
                return payment;
            }
        }

        public async Task<Payment> UpdatePayment(int id, Payment payment)
        {

        Payment paymentToUpdate = await _context.payments.FirstOrDefaultAsync((pay) => pay.Id == id);
            if(paymentToUpdate != null)
            {
                paymentToUpdate.PaymentDate = Convert.ToDateTime(payment.PaymentDate);
                paymentToUpdate.Amount = payment.Amount;
                paymentToUpdate.Method = payment.Method;
                paymentToUpdate.Status = payment.Status;
                paymentToUpdate.BookingId = payment.BookingId;

                await _context.SaveChangesAsync();
                return paymentToUpdate;

            } else
            {
                return null;
            }
        }
    }
}
