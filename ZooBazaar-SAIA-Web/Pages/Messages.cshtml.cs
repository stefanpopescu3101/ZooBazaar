using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Class_Library.Object_Classes;
using Class_Library.Data_Access;

namespace ZooBazaar_SAIA_Web.Pages
{
    public class MessagesModel : PageModel
    {
        
        [BindProperty]
        [Required(ErrorMessage = "Please enter a message.")]
        public string MessageText { get; set; }
        public List<Message> messages;

        private MessageDb messageDb = new MessageDb();

        public IActionResult OnGet()
        {
            messages = messageDb.GetAllMessages();
            return Page();
        }

        public IActionResult OnPost() {
            if (ModelState.IsValid) {
                Message message = new Message(MessageText);
                int id = messageDb.AddNewMessage(message);
                messages = messageDb.GetAllMessages();
                return Page();
            } else {
                messages = messageDb.GetAllMessages();
                return Page();
            }
        }
    }
}
