using WineCellar.API.Models;

namespace WineCellar.API.Repository
{
    public interface ICellarRepository
    {
        User GetUser(Guid id);

        IEnumerable<Wine> GetAllWines();
        Wine GetWine(Guid id);
        Wine CreateWine(Wine wine);
        Wine EditWine(Wine wine);
        Wine DeleteWine(Guid id);

        IEnumerable<Tag> GetAllTags();
        Tag GetTag(Guid id);
        Tag CreateTag (Tag tag);
        Tag EditTag(Tag tag);
        Tag DeleteTag(Guid id);

        IEnumerable<WineTag>GetAllWineTags();
        WineTag GetWineTag(Guid id);
        WineTag CreateWineTag(WineTag wineTag);
        WineTag EditWineTag(WineTag wineTag);
        WineTag DeleteWineTag(Guid id);


    }
}
