// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using EcmaSharp.Benchmarks;

BenchmarkRunner.Run<ASTGeneration>();
