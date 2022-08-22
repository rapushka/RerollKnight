using Code.Services.Interfaces;

namespace Code.Services.Realizations
{
	class IntIdentifierService : IIdentifierService<int>
	{
		private int _current;

		public IntIdentifierService()
		{
			_current = 1;
		}
		
		public int Next() => _current++;
	}
}