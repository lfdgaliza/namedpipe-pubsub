using Producer;

IMessagePublisher publisher = new MessagePublisher();
Thread.Sleep(2000); // To give time to the subscriber to be found

publisher.PublishMessage("It works!");
publisher.PublishMessage("It works!!");
publisher.PublishMessage("It works!!!");