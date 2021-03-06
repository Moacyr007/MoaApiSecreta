﻿using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseRepository<T> : IReposotory<T> where T : BaseEntity

    {
        protected readonly MyContext _context;
        private DbSet<T> _dataset;

        public BaseRepository(MyContext context)
        {
            _context = context;
            _dataset = context.Set<T>();
        }
        public async Task<bool> DeletAsync(Guid id)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id) && p.Excluido.Equals(false));

            if (result == null)
                return false;

            result.Excluido = true;

            await UpdateAsync(result);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<T> InsertAsync(T item)
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.CreateAt = DateTime.UtcNow;
            _dataset.Add(item);

            item.UpdateAt = null;
            item.Excluido = false;

            await _context.SaveChangesAsync();

            return item;
        }

        public async Task<bool> ExistAsync(Guid id)
        {
            return await _dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<T> SelectAsync(Guid id)
        {
            return await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<IEnumerable<T>> SelectAsync()
        {
            return await FindAll()
                             .Where(x => x.Excluido != true)
                             .ToListAsync();

        }

        public IEnumerable<T> Select()
        {
            return _dataset.ToList();
        }

        public async Task<T> UpdateAsync(T item)
        {
            var result = await _dataset.SingleOrDefaultAsync(p => p.Id.Equals(item.Id) && p.Excluido.Equals(false));

            if (result == null)
            {
                return null;
            }

            item.UpdateAt = DateTime.UtcNow;
            item.CreateAt = result.CreateAt;

            _context.Entry(result).CurrentValues.SetValues(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public IQueryable<T> FindAll()
        {
            return _context.Set<T>();
        }

        public async Task<List<T>> GetPaginate(PaginateParameters paginateParameters)
        {
            return await FindAll()
                .Where(x => x.Excluido != true)
                .OrderByDescending(on => on.CreateAt)
                .Skip((paginateParameters.Pagina - 1) * paginateParameters.TamanhoPagina)
                .Take(paginateParameters.TamanhoPagina)
                .ToListAsync();
        }

        public async Task<int> Count()
        {
            return await FindAll()
                .CountAsync();
        }

    }
}
