cil
===

Common Intermediate Language (.NET/Mono/CSharp) support for metafolder

### MetaFolder

Some philosophers say that you can't *step into the same river twice*. Most computer people say that you *can't put the same file into two folders*.

Sure you can copy it, but that just trades one organization problem for a storage-eating, "one of these is out of date" problem.

So what is a hyper-organized, space-saving frugalista to do? Devise a perfect tree-based organization scheme that works with the file system as we know it? Transcend to a higher folder plane? After failing at the prior, I seek the latter.

### Motivation
What is the point of making a folder "meta"? It is simple, really: take your curated content out of the tree and make it work more like "tags" in Gmail, or "labels" in a blog. Why? Because otherwise your organization scheme is limited to putting each "thing" in a single "bucket". 

> Ask yourself: does that selfie of me at Mt. Rainier go in the "travel", "selfie", "outdoors", "nature", "rain", "backpacking", or "vacation" folder? If you have to pick just one, likely you are either just putting it in a generic "photos" bucket or a "Mt. Rainier - 2013" bucket. Now when you need a recent selfie, you have to remember that you took one at Mt. Rainier. Surely there is a better use for your memory. Isn't that why we have computers in the first place?

### Solution

The metafolder solution is trying to find a happy medium between a few priorities:
* Fail-safe archival of content
* Searchable, Tag-based organization of content
* Platform "agnostic" storage representations for redundancy and "future proofing"
* Standards-based mapping to current filesystems
* Support for "the cloud" but no over reliance on it or any one provider in it
* Redundant array of inexpensive cloud
* Super simple "end user" UI for organizing and importing (my wife is savvy, but has little patience for the command line)

To achieve this, metafolder maps a model of "primitives" to specific implementations, with a built-in way to migrate and sync content:

* Identifier: A calculated "signature" of the actual bits of a piece of content (hash). Example: MurMur3 Hash of the bytes of a file.
* Representation: A single scheme for storing a tag-based archive of content. Examples: NTFS Files/Folders Representation, or Amazon S3 representation.
* Repository: An archive of data using a specific representation. Example: I have a "video" repository and a "photo" repository stored on my External HDD.
* Index: Analogous to the database concept...A structure supporting a fast search for items that have tags and/or tagged values.
* Tag: Either a "marker" (where the occurrence of the tag is all that is tracked) or a tag/value pair. Example: F-Stop=2.8

### Scope

This approach works best for files that aren't likely to change much (if any). Digital pictures, home video, and audio files are all good examples. Word documents not so much.

### Status

This is a "free time" project for @automatonic, so it will progress as he has free time. That said, @automatonic would love to safely and cleanly organize his archives as soon as possible. Star and follow for updates. Planned features:

* Complete support for storage in a local file system
* Amazon S3 support
* Amazon Glacier support?
* A GUI app for managing, tagging, importing and syncing

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
