using CoYBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoYBackend.Services
{
  public class Validator : ControllerBase
  {
    public ActionResult Error(int Id, DbUpdateConcurrencyException e, CoYBackendContext context)
    {
      if (!context.users.Any(e => e.Id == Id)) //Check if User user paramater exists in database
      {
        return NotFound();
      }
      else
      {
        throw (e);
      }
    }
  }
}