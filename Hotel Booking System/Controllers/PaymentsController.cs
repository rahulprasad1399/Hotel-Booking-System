using Hotel_Booking_System.DTO;
using Hotel_Booking_System.Models;
using Hotel_Booking_System.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hotel_Booking_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            List<Payment> payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayment(int id)
        {
            Payment payment = await _paymentService.GetPayment(id);
            if (payment == null)
            {
                return NotFound("Payment with the provided id dosen't exist");
            }
            else
            {
                return Ok(payment);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentPostDto paymentPostDto)
        {

            Payment payment = new Payment()
            {
                PaymentDate = Convert.ToDateTime(paymentPostDto.PaymentDate),
                Amount = paymentPostDto.Amount,
                Method = paymentPostDto.Method,
                Status = paymentPostDto.Status,
                BookingId = paymentPostDto.BookingId,
            };

            Payment newPayment = await _paymentService.CreatePayment(payment);
            return Ok(newPayment);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePayment(int id, PaymentPostDto paymentPostDto)
        {

            Payment payment = new Payment()
            {
                PaymentDate = Convert.ToDateTime(paymentPostDto.PaymentDate),
                Amount = paymentPostDto.Amount,
                Method = paymentPostDto.Method,
                Status = paymentPostDto.Status,
                BookingId = paymentPostDto.BookingId,
            };

            Payment updatedPayment = await _paymentService.UpdatePayment(id, payment);
            return Ok(updatedPayment);

        }

        [HttpDelete]
        public async Task<IActionResult> DeletePayment(int id)
        {
            Payment payment = await _paymentService.DeletePayment(id);
            if (payment == null)
            {
                return NotFound("Payment with the provided id not found");
            }
            else
            {
                return Ok(payment);
            }
        }

    }
}
