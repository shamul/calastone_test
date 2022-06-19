// See https://aka.ms/new-console-template for more information
using CalastoneTest.Filter;
using CalastoneTest.Pipeline;
using CalastoneTest.Repo;
using System.IO.Abstractions;

var fileRepo = new FileDataRepo(new FileSystem());
fileRepo.Path = @"Z:\code\calastone_test\CalastoneTest\CalastoneTest\Input.txt";

var cFilter = new ContainCharacterFilter('t');
var mFilter = new MinimumLengthFilter(3);
var vFilter = new VowelMiddleFilter();

var pipeline = new FilterPipeline();
pipeline.AddFilter(vFilter);
pipeline.AddFilter(mFilter);
pipeline.AddFilter(cFilter);

var result = pipeline.Process(fileRepo.GetData());

foreach (var item in result)
{
    Console.WriteLine(item);
}

