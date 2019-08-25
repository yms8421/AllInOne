using Microsoft.EntityFrameworkCore;
using Perque.Business.Abstractions;
using Perque.Contracts.Dtos;
using Perque.Contracts.Dtos.Productivity;
using Perque.Data;
using Perque.Entities.Productivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Perque.Business
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IRepository<Category> repo;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            repo = unitOfWork.GetRepository<Category>();
        }
        public IEnumerable<BasicDetailedInfoDto> GetCategories()
        {
            var result = repo.Include(i => i.SubCategories)
                .Select(i => new BasicDetailedInfoDto
                {
                    Id = i.Id,
                    Name = i.Name,
                    Children = i.SubCategories.Select(a => new BasicDetailedInfoDto
                    {
                        Id = a.Id,
                        Name = a.Name
                    }).ToList()
                }).ToList();
            return result;
        }

        public BasicDetailedInfoDto GetCategory(int id)
        {
            var category = repo.Include(i => i.SubCategories)
                                .Select(i => new BasicDetailedInfoDto
                                {
                                    Name = i.Name,
                                    Id = i.Id,
                                    Children = i.SubCategories.Select(a => new BasicDetailedInfoDto
                                    {
                                        Id = a.Id,
                                        Name = a.Name
                                    }).ToList()
                                }).FirstOrDefault(i => i.Id == id);

            return category;
        }

        public bool NewCategory(CategoryDto data)
        {
            var category = new Category
            {
                Name = data.Name,
                IsActive = true
            };
            repo.Add(category);
            var subCatRepo = unitOfWork.GetRepository<SubCategory>();
            foreach (var sc in data.SubCategories)
            {
                var newSc = new SubCategory
                {
                    Name = sc.Name,
                    IsActive = true,
                    CategoryId = category.Id
                };
                subCatRepo.Add(newSc);
            }
            return unitOfWork.SaveChanges() > 0;
        }
    }
}
