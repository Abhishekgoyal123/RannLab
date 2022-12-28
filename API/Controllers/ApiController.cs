using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using System.Reflection.Metadata.Ecma335;

namespace API.Controllers
{
    [Route("api/[Action]")]
    [ApiController]

    
    public class ApiController : ControllerBase
    {
        deviceregisterContext context;

        public ApiController()
        {
            context = new deviceregisterContext();
        }

        [HttpPost]

        public IActionResult DeviceRegister(DeviceObject device)
        {
             DeviceDetail detail = new DeviceDetail();
            detail.Mac = device.MAC;
            detail.AddedOn = DateTime.UtcNow;
            detail.BusinessLocation = device.BusinessLocation;
            detail.GenderPrefrence = device.Genderpreference;
           
            if (detail.GenderPrefrence != "Male" || detail.GenderPrefrence != "Female" || detail.GenderPrefrence != "Kids" || detail.GenderPrefrence != "All")
            {
                return BadRequest("Please enter gender as Male, Female, Kids, or All");
            }
            else
            {
                context.DeviceDetails.AddAsync(detail);
                context.SaveChangesAsync();

                return Ok("Device registered successfully");

            }

        }

        [HttpGet]

        public IActionResult FetchAds()
        {
            var result = from adInfo in context.AdsInfos
                      join adLoc in context.Adslocations on adInfo.AdsId equals adLoc.AdsId
                      select new
                      {
                          adInfo.AdsId,
                          adInfo.YoutubeUrl,
                          adLoc.BusinessLocation,
                          adInfo.Gender,
                          adInfo.AddedOn,
                          adInfo.ExpiredOn
                      };
            
            return Ok(result);
        }

        [HttpPost]

         public IActionResult RunAds(int adId, int deviceId)
         {
            AdMapping adMapping = new AdMapping();
            adMapping.AdsId = adId;
            adMapping.DeviceId = deviceId;
            context.AdMappings.AddAsync(adMapping);
            context.SaveChangesAsync();
            return Ok("Ad registered with device");
         }

        [HttpPost]

        public IActionResult viewsCount(int adId)
        {
            var viewsCount = (from AdMapping in context.AdMappings
                             where AdMapping.AdsId == adId
                             select AdMapping).Count();
            return Ok($"total views for adId = {adId} are {viewsCount}");

        }


    }
}
