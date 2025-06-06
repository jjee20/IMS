﻿using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class AttendanceRepository : BaseRepository, IAttendanceRepository
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        private ApplicationDataContext _db;
        public AttendanceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
