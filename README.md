cil
===

Common Intermediate Language (.NET/Mono/CSharp) support for metafolder

`metafolder` Specification
=============

The `metafolder` concept is mostly one of convention. As such, a single platform+language implementation should be sufficient to demonstrate the key points. However, since one of the goals is to avoid "vendor lock-in", a clear specification would be needed to help ensure a consistent functionality across programming languages and computing platforms.

Overview
--------

`metafolder` takes cues from a range of web technologies. All primitives are identified using the well-defined grammars of a URI, and where possible, existing paradigms (REST, etc.) are leveraged.   

Primitives
----------

An implementation of this specification need not be in any specific language or for any specific computing platform. That said, an implementor must support the base primitives in order to comply.


Importing
---------

It is assumed that there is a gradual and continual collection of content. For example, a photo archive will continually be growing as new photos are taken. The process of adding new content, avoiding duplication, and the import of metadata is to be well defined.

Synchronization
---------------
