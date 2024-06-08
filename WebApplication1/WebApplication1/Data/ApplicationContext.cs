using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Prescription> Prescriptions { get; set; }
    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Medicament>().HasData(new List<Medicament>()
        {
            new () {IdMedicament = 1, Name = "apap", Description = "bardzo pomaga", Type = "tabletka"},
            new () {IdMedicament = 2, Name = "masc do reki", Description = "należy nałożyc dużo ilosc", Type = "maść"},
            new () {IdMedicament = 3, Name = "maść do nogi", Description = "należy nałożyc mało ilosc", Type = "maść"}
        });

        modelBuilder.Entity<Doctor>().HasData(new List<Doctor>()
        {
            new () {IdDoctor = 1, FirstName = "Ala", LastName = "Kowalska", Email = "ala@wp.pl"},
            new () {IdDoctor = 2, FirstName = "Tomek", LastName = "Nowak", Email = "Tomek@wp.pl"},
            new () {IdDoctor = 3, FirstName = "Kuba", LastName = "Kowalska", Email = "Kuba@wp.pl"}
        });

        modelBuilder.Entity<Patient>().HasData(new List<Patient>()
        {
            new () {IdPatient = 1, FirstName = "Antek", LastName = "Kowalski", Birthdate = DateTime.Now},
            new () {IdPatient = 2, FirstName = "Lola", LastName = "Nowakowska", Birthdate = DateTime.Now},
            new () {IdPatient = 3, FirstName = "Ula", LastName = "Uzu", Birthdate = DateTime.Now}
        });

        modelBuilder.Entity<Prescription>().HasData(new List<Prescription>()
        {
            new () { IdPrescription = 1, Date = DateTime.Now, DueDate = DateTime.Now, IdPatient = 2, IdDoctor = 1},
            new () { IdPrescription = 2, Date = DateTime.Now, DueDate = DateTime.Now, IdPatient = 1, IdDoctor = 2},
            new () { IdPrescription = 3, Date = DateTime.Now, DueDate = DateTime.Now, IdPatient = 3, IdDoctor = 1},
            new () { IdPrescription = 4, Date = DateTime.Now, DueDate = DateTime.Now, IdPatient = 1, IdDoctor = 1}
        });

        modelBuilder.Entity<PrescriptionMedicament>().HasData(new List<PrescriptionMedicament>()
        {
            new () {IdMedicament = 1, IdPrescription = 3, Dose = 2, Details = "saasdasdasd"},
            new () {IdMedicament = 2, IdPrescription = 2, Dose = 2, Details = "xxx"},
            new () {IdMedicament = 1, IdPrescription = 2, Dose = 2, Details = "bbb"},
            new () {IdMedicament = 3, IdPrescription = 2, Dose = 12, Details = "xa"},
            new () {IdMedicament = 4, IdPrescription = 4, Dose = 9, Details = "x"}
        });



    }
}