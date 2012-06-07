Console Dot Test
================

This is an extremely simple application used by yours truly to test Python's `subprocess`, .NET's `System.Diagnostics.Process`, etc.

The help output says it all.

```
Usage: ConsoleDotTest.exe [OPTIONS]
  Facilitates some basic command-line operations, for testing purposes.

Options:
  -h, --help                 show this help message
  -i, --stdin                reads in 3 lines from STDIN, which will be
                               echoed back on STDOUT before termination
  -e, --stderr               output a message to STDERR
  -o, --stdout               output a message to STDOUT
  -w, --wait                 wait 3 seconds before terminating
  -f, --fail                 terminate with a non-zero exit code
```