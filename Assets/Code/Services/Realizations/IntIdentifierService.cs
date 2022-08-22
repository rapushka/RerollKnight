using Code.Services.Interfaces;

namespace Code.Services.Realizations
{
	public class IntIdentifierService : IIdentifierService<int>
	{
		private int _current;
		
		public int Next() => _current++;
	}
}