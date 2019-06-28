using WApp.Api.Infraestructure.Data.Entities;

namespace WApp.Api.Modules.OnlineStore.Interfaces
{
    public interface ICompanyService
    {
        CompInfo GetCompany(string companyId);
        CompInfo Add(CompInfo company);
        CompInfo Update(CompInfo company);
    }
}
