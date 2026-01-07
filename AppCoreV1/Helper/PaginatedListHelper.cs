using AppCoreV1.ABLEModels;

namespace AppCoreV1.Helper
{
    public class PaginatedListHelper
    {
        public static PaginatedList<PartySearch> GetPartySearch()
        {
            PartySearch _defaultParty = new PartySearch();
            List<PartySearch> _list = new List<PartySearch>();
            _list.Add(_defaultParty);
            PaginatedList<PartySearch> _party = new PaginatedList<PartySearch>(_list, 1, 1, 1);

            return _party;
        }

        public static PaginatedList<Case> GetCase()
        {
            Case _defaultCase = new Case();
            List<Case> _list = new List<Case>();
            _list.Add(_defaultCase);
            PaginatedList<Case> _cases = new PaginatedList<Case>(_list, 1, 1, 1);

            return _cases;
        }
    }
}
