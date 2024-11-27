using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ct.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace ct.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CtItemController : ControllerBase
    {
        private readonly CtContext _context;
        String ConnectionString = "data source=10.2.60.78;initial catalog=Directorio;user id=sa;password=2en1;MultipleActiveResultSets=True;;Connection Timeout=60;Trusted_Connection=true;TrustServerCertificate=true;Encrypt=false;Integrated Security=False;";
        public CtItemController(CtContext context)
        {
            _context = context;
        }

        // GET: api/CtItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CtItem>>> GetCtItems()
        {
            return await _context.CtItems.ToListAsync();
        }
        [HttpGet("test")]
public async Task<IActionResult> testconnection()
{
    SqlConnection connection = new SqlConnection(ConnectionString); // Usar el campo ConnectionString correctamente
    SqlCommand command = new SqlCommand();
    command.Connection = connection;
    await connection.OpenAsync();

    command.CommandText = "Select * from dbo.TC_DirectorioNuevo where NOMBRE = @name";
    command.CommandType = System.Data.CommandType.Text;

    command.Parameters.AddWithValue("@name", "Daniel");

    SqlDataReader reader = await command.ExecuteReaderAsync();
    List<string> lista = new List<string>();
    if (!await reader.ReadAsync())
    {
        //error
    }

    do
    {
        string dependencia = (string)reader["DEPENDENCIA"];
        lista.Add(dependencia);
    }
    while (await reader.ReadAsync());

    await reader.CloseAsync();
    await connection.CloseAsync();
    connection.Dispose();

    return Ok(lista);
}

// GET: api/CtItem/5
        [HttpGet("First")]
        public async Task<ActionResult<CtItem>> GetCtItem()
        {
            var ctItem = _context.CtItems.FirstOrDefault();

            if (ctItem == null)
            {
                return NotFound();
            }

            return ctItem;
        }

        // GET: api/CtItem/5
        [HttpGet("{name}")]
        public async Task<ActionResult<CtItem>> GetCtItem(string name)
        {
            var ctItem = _context.CtItems.Where(x=> x.NOMBRE == name).FirstOrDefault();

            if (ctItem == null)
            {
                return NotFound();
            }

            return ctItem;
        }

        // PUT: api/CtItem/5
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//         [HttpPut("{Daneil}")]
//         public async Task<IActionResult> PutCtItem(long id, CtItem CtItem)
//         {
//             if (id != CtItem.Id)
//             {
//                 return BadRequest();
//             }

//             _context.Entry(CtItem).State = EntityState.Modified;

//             try
//             {
//                 await _context.SaveChangesAsync();
//             }
//             catch (DbUpdateConcurrencyException)
//             {
//                 if (!CtItemExists("Daniel"))
//                 {
//                     return NotFound();
//                 }
//                 else
//                 {
//                     throw;
//                 }
//             }

//             return NoContent();
//         }

//         // POST: api/CtItem
//         // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
// public async Task<ActionResult<CtItem>> PostTodoItem(CtItem CtItem)
// {
//     _context.CtItems.Add(CtItem);
//     await _context.SaveChangesAsync();

//     //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
//     return CreatedAtAction(nameof(GetCtItem), new { id = CtItem.Id }, CtItem);
// }

//         // DELETE: api/CtItem/5
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeleteCtItem(long id)
//         {
//             var ctItem = await _context.CtItems.FindAsync(id);
//             if (ctItem == null)
//             {
//                 return NotFound();
//             }

//             _context.CtItems.Remove(ctItem);
//             await _context.SaveChangesAsync();

//             return NoContent();
//         }

//         private bool CtItemExists(long id)
//         {
//             return _context.CtItems.Any(e => e.Id == id);
//         }
//     }
    }
}
