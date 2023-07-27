using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using BehaviourTreeTests.BehaviorTree;
using BehaviourTreeTests.BehaviorTree.Nodes;

public class BhTreeIntegrationTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void SimpleTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        Node testRoot = new Success(testTree.DataContext);

        testTree.Setup(testRoot);

        testTree.Execute(1f);

        Assert.AreEqual("Success", testTree.GetSequence());
    }

    [Test]
    public void SimpleRepeaterTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new Repeater(context, new Success(testTree.DataContext));
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("Repeater/Success/Repeater/Success/Repeater/Success", testTree.GetSequence());
    }

    [Test]
    public void SimpleRepeatUntilFailTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new RepeatUntilFail(context, new Fail(testTree.DataContext));
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("RepeatUntilFail/Fail", testTree.GetSequence());
    }

    [Test]
    public void InverterNegativeAndUntilFailTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new RepeatUntilFail(context, new Inverter(context, new Fail(testTree.DataContext)));
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("RepeatUntilFail/Inverter/Fail/RepeatUntilFail/Inverter/Fail", testTree.GetSequence());
    }

    [Test]
    public void InverterPositiveAndUntilFailTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new RepeatUntilFail(context, new Inverter(context, new Success(testTree.DataContext)));
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("RepeatUntilFail/Inverter/Success", testTree.GetSequence());
    }

    [Test]
    public void SimpleSucceederTestTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new RepeatUntilFail(context, new Succeeder(context, new Fail(testTree.DataContext)));
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("RepeatUntilFail/Succeeder/Fail/RepeatUntilFail/Succeeder/Fail", testTree.GetSequence());
    }

    [Test]
    public void SimpleSequencerNegativeTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new Sequencer(context, new List<Node>() {
                new Success(context),
                new Inverter(context, new Fail(context)),
                new Fail(context),
                new Success(context)
                });
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("Sequencer/Success/Inverter/Fail/Fail", testTree.GetSequence());
    }

    [Test]
    public void SimpleSequencerPositiveTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new Sequencer(context, new List<Node>() {
                new Success(context),
                new Inverter(context, new Fail(context)),
                new Success(context)
                });
        testTree.Setup(testRoot);

        testTree.Execute(1f);

        Assert.AreEqual("Sequencer/Success/Inverter/Fail/Success", testTree.GetSequence());
    }

    [Test]
    public void SimpleSelectorPositiveTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new Selector(context, new List<Node>() {
                new Fail(context),
                new Inverter(context, new Success(context)),
                new Success(context),
                new Fail(context)
                });
        testTree.Setup(testRoot);

        testTree.Execute(1f);

        Assert.AreEqual("Selector/Fail/Inverter/Success/Success", testTree.GetSequence());
    }

    [Test]
    public void SimpleRandomSelectorPositiveTreeExecutionTest()
    {
        // BAD TEST: Since there is randomness involved, there is a small chance 
        // that we can get the same sequence and thus fail the test with good functionality.

        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new RandomSelector(context, new List<Node>() {
                new Fail(context),
                new Inverter(context, new Success(context)),
                new Success(context),
                new Fail(context),
                new Fail(context),
                new Fail(context),
                new Fail(context),
                new Fail(context),
                new Fail(context),
                new Fail(context),
                new Fail(context)
                });
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        string sequenceOne = testTree.GetSequence();
        testTree.Execute(1f);
        string sequenceTwo = testTree.GetSequence();

        Assert.AreNotEqual(sequenceOne, sequenceTwo);
    }

    [Test]
    public void ACompositeKeepsRunningTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new Sequencer(context, new List<Node>() {
                new Success(context),
                new Inverter(context, new Fail(context)),
                new Success(context),
                new RunForever(context),
                new Fail(context)
                });
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);
        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("Sequencer/Success/Inverter/Fail/Success/RunForever/Sequencer/RunForever/Sequencer/RunForever/Sequencer/RunForever", testTree.GetSequence());
    }

    [Test]
    public void KeepsRunningWhereNeededTreeExecutionTest()
    {
        // Use the Assert class to test conditions
        BhTree testTree = new(true);
        DataContext context = testTree.DataContext;

        Node testRoot = new RepeatUntilFail(context,  new RunXTimes(testTree.DataContext, 2, RunStates.FAILURE));
        testTree.Setup(testRoot);

        testTree.Execute(1f);
        testTree.Execute(1f);
        testTree.Execute(1f);
        testTree.Execute(1f);

        Assert.AreEqual("RepeatUntilFail/RunXTimes/RepeatUntilFail/RunXTimes", testTree.GetSequence());
    }
}
