using System;
using System.Security;
using DAL.Models;
using DAL.Repositories;
using Patterns.Services;

namespace Patterns.Proxy
{
    public class ProxyRepository<TEntity> : IChangeRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        private readonly IRepository<TEntity> _repository;
        private readonly Role _userRole;

        public ProxyRepository(IRepository<TEntity> repository, IAuthenticationService authenticationService)
        {
            _repository = repository;
            _userRole = authenticationService.GetUser().Role;
        }

        public TEntity Add(TEntity entity)
        {
            Validate();

            return _repository.Add(entity);
        }

        public void DeleteById(int id)
        {
            Validate();

            _repository.DeleteById(id);
        }

        public void Update(TEntity entity)
        {
            Validate();

            _repository.Update(entity);

        }

        private void Validate()
        {
            if(!CheckAccess)
            {
                throw new SecurityException("Only admin can change entity.");
            }
        }

        private bool CheckAccess => _userRole.Type == RoleType.Admin;
    }
}