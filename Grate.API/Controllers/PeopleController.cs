using System.Data;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Grate.API.Controllers
{
    [ApiController]
    [Route("people")]
    public class PeopleController : ControllerBase
    {
        private readonly IDbConnection _db;

        public PeopleController(IDbConnection db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> Get()
        {
            var people = await _db.QueryAsync<Person>("[dbo].[GetAllPeople]");
            return Ok(people);
        }

        [HttpPut]
        public async Task<ActionResult<Person>> Put(Person person)
        {
            var sql = @"
UPDATE Person SET Forename = @Forename
, Surname = @Surname
, Dob = @Dob
WHERE Id = @Id
";
            var rows = await _db.ExecuteAsync(sql, person);

            return rows < 1 ? StatusCode(500) : NoContent();
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public DateTime Dob { get; set; }
    }
}