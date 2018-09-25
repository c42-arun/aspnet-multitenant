using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class SpeakerController : MultiTenantMvcController
    {
        public async Task<ActionResult> Index()
        {
            var speakers = new List<Speaker>();
            
            using (var context = new MultiTenantContext())
            {
                var speakersAll = await context.Speakers.ToListAsync();

                foreach (var speaker in speakersAll)
                {
                    bool speakerInTenant = speaker.Sessions.Any(a => a.Tenant.Name == Tenant.Name);

                    if (speakerInTenant)
                    {
                        speakers.Add(new Speaker
                        {
                            FirstName = speaker.FirstName,
                            LastName = speaker.LastName,
                            Id = speaker.Id,
                            Bio = speaker.Bio,
                            Website = speaker.Website,
                            AllowHtml = speaker.AllowHtml,
                            ImageUrl = speaker.ImageUrl,
                            PictureId = speaker.PictureId,
                            Sessions =
                                speaker.Sessions
                                    .Where(a => a.Tenant.Name == Tenant.Name)
                                    .OrderBy(a => a.Title).ToList()
                        });
                    }
                }
            }

            return View("Index", speakers);
        }
    }
}