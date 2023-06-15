﻿using WineCellar.API.Models;
using WineCellar.API.Models.Tags;
using WineCellar.API.Models.Users;
using WineCellar.API.Models.Wines;
using WineCellar.API.Models.WineTags;

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
