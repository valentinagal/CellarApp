using WineCellar.API.Models;
using WineCellar.API.Models.Tags;
using WineCellar.API.Models.Users;
using WineCellar.API.Models.Wines;
using WineCellar.API.Models.WineTags;

namespace WineCellar.API.Repository
{
    public interface ICellarRepository
    {
        IEnumerable<User>GetAllUsers();
        User GetUser(Guid id);
        User CreateUser(CreateUser user);

        IEnumerable<Wine> GetAllWines();
        Wine GetWine(Guid id);
        Wine CreateWine(CreateWine wine);
        Wine? EditWine(Guid id, CreateWine wine);
        Wine DeleteWine(Guid id);

        IEnumerable<Tag> GetAllTags();
        Tag GetTag(Guid id);
        Tag CreateTag (CreateTag tag);
        Tag EditTag(CreateTag tag);
        Tag DeleteTag(Guid id);

        IEnumerable<WineTag>GetAllWineTags();
        WineTag GetWineTag(Guid id);
        WineTag CreateWineTag(WineTag wineTag);
        WineTag EditWineTag(WineTag wineTag);
        WineTag DeleteWineTag(Guid id);


    }
}
