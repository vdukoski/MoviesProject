using PrymApp.Data.Model;
using PrymApp.Data.Repository;
using PrymApps.Business.DtoModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PrymApps.Business.Service
{
    public class MovieService : BaseService<MovieRepository>, IService<DtoMovie>
    {
        public ServiceResult<DtoMovie> Add(DtoMovie item)
        {
            try
            {
                var result = Repository.Create(new Movie()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Genre = item.Genre,
                    DirectorName = item.DirectorName,
                    ReleaseDate = item.ReleaseDate,
                   

                });
                return new ServiceResult<DtoMovie>()
                {
                    Item = new DtoMovie(result),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMovie>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMovie> Edit(DtoMovie item)
        {
           try
            {
                if((item?.Id ?? 0) > 0)
                {
                    var dbMovie = Repository.Get(item.Id);
                    if (dbMovie == null)
                        return new ServiceResult<DtoMovie>
                        {
                            Success = false,
                            ErrorMessage = "Movie not found"
                        };
                    Repository.Update(new Movie
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DirectorName = item.DirectorName,
                        ReleaseDate = item.ReleaseDate,
                        Genre = item.Genre

                    });
                    return new ServiceResult<DtoMovie>
                    {
                        Success = true,
                        Item = new DtoMovie(dbMovie)
                    };

                }
                return new ServiceResult<DtoMovie>
                {
                    Success = false,
                    ErrorMessage = "Id is required parameter"
                };
            }
            catch(Exception ex)
            {
                return new ServiceResult<DtoMovie>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMovie> Load(DtoMovie item)
        {
            if ((item?.Id ?? 0) < 1)
            {
                return new ServiceResult<DtoMovie>
                {
                    Success = false,
                    ErrorMessage = "id is a required parameter"
                };
            }

            try
            {
                var dbItem = Repository.Get(item.Id);
                if (dbItem == null)
                    return new ServiceResult<DtoMovie>
                    {
                        Success = false,
                        ErrorMessage = "Movie not found"
                    };

                return new ServiceResult<DtoMovie>
                {
                    Success = true,
                    Item = new DtoMovie(dbItem)
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoMovie>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMovie> LoadAll()
        {
            try
            {
                var movies = Repository.GetAll().ToList();
                var resultList = new List<DtoMovie>();
                movies.ForEach(m => resultList.Add(new DtoMovie(m)));
                return new ServiceResult<DtoMovie>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //Log exception
                return new ServiceResult<DtoMovie>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMovie> Remove(DtoMovie item)
        {
            if ((item?.Id ?? 0) < 1)
            {
                return new ServiceResult<DtoMovie>
                {
                    Success = false,
                    ErrorMessage = "id is a required parameter"
                };
            }

            try
            {
                var dbItem = Repository.Get(item.Id);
                Repository.Delete(dbItem);
                return new ServiceResult<DtoMovie>()
                {
                  
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoMovie>
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}
