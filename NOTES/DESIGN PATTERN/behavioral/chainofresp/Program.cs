using System;

namespace DesignPatterns

{

    // Enum to represent issue severity levels

    public enum IssueSeverity

    {

        Low,

        Medium,

        High

    }

    // Request class

    public class SupportRequest

    {

        public string Description { get; set; }

        public IssueSeverity Severity { get; set; }

        public SupportRequest(string description, IssueSeverity severity)

        {

            Description = description;

            Severity = severity;

        }

    }

    // Handler abstract class

    public abstract class SupportHandler

    {

        protected SupportHandler _nextHandler;

        // Set the next handler in the chain

        public void SetNext(SupportHandler handler)

        {

            _nextHandler = handler;

        }

        // Handle request

        public abstract void HandleRequest(SupportRequest request);

    }

    // Concrete Handler: Level 1 Support

    public class Level1Support : SupportHandler

    {

        public override void HandleRequest(SupportRequest request)

        {

            if (request.Severity == IssueSeverity.Low)

            {

                Console.WriteLine($"Level 1 Support: Resolved '{request.Description}'");

            }

            else if (_nextHandler != null)

            {

                Console.WriteLine("Level 1 Support: Escalating issue...");

                _nextHandler.HandleRequest(request);

            }

        }

    }

    // Concrete Handler: Level 2 Support

    public class Level2Support : SupportHandler

    {

        public override void HandleRequest(SupportRequest request)

        {

            if (request.Severity == IssueSeverity.Medium)

            {

                Console.WriteLine($"Level 2 Support: Resolved '{request.Description}'");

            }

            else if (_nextHandler != null)

            {

                Console.WriteLine("Level 2 Support: Escalating issue...");

                _nextHandler.HandleRequest(request);

            }

        }

    }

    // Concrete Handler: Level 3 Support

    public class Level3Support : SupportHandler

    {

        public override void HandleRequest(SupportRequest request)

        {

            if (request.Severity == IssueSeverity.High)

            {

                Console.WriteLine($"Level 3 Support: Resolved '{request.Description}'");

            }

            else

            {

                Console.WriteLine("Level 3 Support: Cannot handle the issue.");

            }

        }

    }

    // Client

    class ChainOfResponsibilityExample

    {

        static void Main()

        {

            // Handlers

            SupportHandler level1 = new Level1Support();

            SupportHandler level2 = new Level2Support();

            SupportHandler level3 = new Level3Support();

            // Chain setup

            level1.SetNext(level2);

            level2.SetNext(level3);

            // Requests

            var request1 = new SupportRequest("Forgot password", IssueSeverity.Low);

            var request2 = new SupportRequest("Software installation issue", IssueSeverity.Medium);

            var request3 = new SupportRequest("Server down", IssueSeverity.High);

            // Send requests through the chain

            Console.WriteLine("Handling Request 1:");

            level1.HandleRequest(request1);

            Console.WriteLine("\nHandling Request 2:");

            level1.HandleRequest(request2);

            Console.WriteLine("\nHandling Request 3:");

            level1.HandleRequest(request3);

        }

    }

}
