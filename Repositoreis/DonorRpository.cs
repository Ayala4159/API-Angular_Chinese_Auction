using ChineseAuction.Data;
using ChineseAuction.Models;
using Microsoft.EntityFrameworkCore;
namespace ChineseAuction.Repositoreis
{
    public class DonorRpository : IDonorRpository
    {
        private readonly ChinesActionDbContext _context;
        public DonorRpository(ChinesActionDbContext context)
        {
            _context = context;
        }

        // get all donors
        // only manager - manager
        public async Task<IEnumerable<Donor>> GetAllDonorsAsync()
        {
            return await _context.Donors.ToListAsync();
        }

        // get donor by id - donor himself or manager
        public async Task<Donor?> GetDonorByIdAsync(int id)
        {

            return await _context.Donors.Include(d => d.Donations).FirstOrDefaultAsync(d => d.Id == id);
        }

        // add new donor - donor himself or manager
        public async Task AddDonorAsync(Donor donor)
        {
            _context.Donors.Add(donor);
            await _context.SaveChangesAsync();
        }

        // update donor - donor himself or manager
        public async Task<Donor?> UpdateDonorAsync(Donor donor)
        {
            var existing = await _context.Donors.FindAsync(donor.Id);
            if (existing == null) return null;
            _context.Entry(existing).CurrentValues.SetValues(donor);
            await _context.SaveChangesAsync();
            return existing;
        }

        // delete donor - donor himself or manager
        public async Task DeleteDonorAsync(int id)
        {
            var donor = await _context.Donors.FindAsync(id);
            if (donor != null)
            {
                _context.Donors.Remove(donor);
                await _context.SaveChangesAsync();
            }
        }

        // uniq email
        public async Task<bool> DonorEmailExistsAsync(string email, int id)
        {
            var donors = await _context.Donors.ToListAsync();
            return donors.Any(d => d.Email.Equals(email) && d.Id != id);
        }

        // get donor by email
        public async Task<Donor?> GetDonorByEmailAsync(string email)
        {
            return await _context.Donors.FirstOrDefaultAsync(d => d.Email == email);
        }
    }
}