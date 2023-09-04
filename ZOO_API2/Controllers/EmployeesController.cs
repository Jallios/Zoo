using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ZOO_API2.Models;

namespace ZOO_API2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly ZooContext _context;

        public EmployeesController(ZooContext context)
        {
            _context = context;
        }

        // GET: api/Employees
       
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            return await _context.Employees.ToListAsync();
        }

        [HttpPost("SignIn")]
        public IActionResult Token([FromBody] Employee employee)
        {
            var identity = GetIdentity(employee.Login, employee.Password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            if (response == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(response);
            }
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            MD5 md5 = MD5.Create();

            var salt = System.Text.Encoding.UTF8.GetBytes(username);
            var passwordSalty = System.Text.Encoding.UTF8.GetBytes(password);
            var hmacMD5 = new HMACMD5(salt);
            var saltedHash = hmacMD5.ComputeHash(passwordSalty);

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < saltedHash.Length; i++)
            {
                returnValue.Append(saltedHash[i].ToString());
            }


            Employee person = _context.Employees.FirstOrDefault(x => x.Login == username && x.Password == returnValue.ToString());
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.PostId.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        [HttpPost("refresh_token")]
        public async Task<ActionResult> RefreshToken(string access_token)
        {
            var login = GetTokenInfo(access_token);
            Employee user = _context.Employees.FirstOrDefault(x => x.Login == login);

            var identity = GetIdentityRefresh(user.Login, user.Password);

            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }

        private string GetTokenInfo(string token)
        {
            var t = new JwtSecurityTokenHandler().ReadJwtToken(token);

            return t.Claims.FirstOrDefault(x => x.Type == ClaimsIdentity.DefaultNameClaimType).Value;
        }

        private ClaimsIdentity GetIdentityRefresh(string username, string password)
        {
            Employee person = _context.Employees.FirstOrDefault(x => x.Login == username && x.Password == password.ToString());
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.PostId.ToString())
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }

        [HttpPost("SignUp")]
        public async Task<ActionResult<Employee>> SignUp(Employee employee)
        {
            if (_context.Employees == null)
            {
                return Problem("Entity set 'ZooContext.Employees'  is null.");
            }

            var salt = System.Text.Encoding.UTF8.GetBytes(employee.Login);
            var passwordSalty = System.Text.Encoding.UTF8.GetBytes(employee.Password);
            var hmacMD5 = new HMACMD5(salt);
            var saltedHash = hmacMD5.ComputeHash(passwordSalty);

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < saltedHash.Length; i++)
            {
                returnValue.Append(saltedHash[i].ToString());
            }

            Employee employee2 = new Employee()
            {
                Surname = employee.Surname,
                Name = employee.Name,
                Patronymic = employee.Patronymic,
                Login = employee.Login,
                Password = returnValue.ToString(),
                PassportData = employee.PassportData,
                PostId = employee.PostId,
                MedicalBookId = employee.MedicalBookId,
                ConcatId = employee.ConcatId,
                StatusEmployeeId = employee.StatusEmployeeId,

            };

            _context.Employees.Add(employee2);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee2.IdEmployee }, employee2);
        }

        // GET: api/Employees/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int? id)
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployee(int? id, Employee employee)
        {
            if (id != employee.IdEmployee)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
        {
          if (_context.Employees == null)
          {
              return Problem("Entity set 'ZooContext.Employees'  is null.");
          }
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployee", new { id = employee.IdEmployee }, employee);
        }

        // DELETE: api/Employees/5
        [Authorize(AuthenticationSchemes = "Bearer", Roles = "2")]
        [LimitRequests(MaxRequests = 2, TimeWindow = 5)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int? id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeExists(int? id)
        {
            return (_context.Employees?.Any(e => e.IdEmployee == id)).GetValueOrDefault();
        }
    }
}
