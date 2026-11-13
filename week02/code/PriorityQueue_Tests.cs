using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enque 3 items with different priorities and then deque them all
    // Expected Result: Items should be dequed in order of the highest priority first, then the next highest, and so on.
    // Defect(s) Found: The highest priority item was not being returned. expected Item3 but actual result was Item2.
    // the error was in the Dequeue method, the for loop was not iterating through the entire queue.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        
       priorityQueue.Enqueue("Item1",1);
       priorityQueue.Enqueue("Item2",2);
       priorityQueue.Enqueue("Item3",3);

       Assert.AreEqual("Item3", priorityQueue.Dequeue());
       Assert.AreEqual("Item2", priorityQueue.Dequeue());
       Assert.AreEqual("Item1", priorityQueue.Dequeue());
        

    }

    [TestMethod]
    // Scenario: Enque 3 items with the same priority and then deque them all
    // Expected Result: Items should be dequed in the order they were enqued(fifo)
    // Defect(s) Found: expected Item1 but actual result was Item2. The error was because of the comparison operator in the Dequeue method. It was using >= instead of >, which caused the last item to be returned instead of the first item.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1",1);
        priorityQueue.Enqueue("Item2",1);
        priorityQueue.Enqueue("Item3",1);

        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());

    }

    // Add more test cases as needed below.
    [TestMethod]
    // Scenario: Attempt to dequeue from an empty priority queue
    // Expected Result: Should throw an exception
    // Defect(s) Found: No defects found. The test passed.
    public void TestPriorityQueue_Empty()
    {
        var priorityQueue = new PriorityQueue();
        try 
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected an InvalidOperationException to be thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
        catch (Exception)
        {
            Assert.Fail("Expected an InvalidOperationException to be thrown.");
        }
        Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
         

    }




}