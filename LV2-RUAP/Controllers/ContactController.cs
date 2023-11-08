using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly ContactRepository _contactRepository;

        public ContactController(ContactRepository contactRepository)
        {
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var contacts = _contactRepository.GetAllContacts();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
