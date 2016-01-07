using System;

// Entry point for application

namespace XNAControllerTest
{
    static class Program
    {
	static void Main()
	{
	    using(Game game = new Game())
	    {
		game.Run();
	    }
	}
    }
    
};
