using AutoService.Shared;

namespace AutoService.Api
{
    public interface IWorkService
    {
        void Add(Work work);

        void Delete(string id);

        List<Work> Get();

        Work Get(string id);

        void Update( Work work);
    }
}
