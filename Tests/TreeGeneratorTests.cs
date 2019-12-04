using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CommentTrees.Helpers;
using CommentTrees.Models.Database;
using CommentTrees.Models.View;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TreeGeneratorTests
    {
        public List<Comment> DatabaseComments { get; private set; }

        [OneTimeSetUp]
        public void SetUp()
        {
            DatabaseComments = new List<Comment>()
            {
                new Comment {Id = 1, ItemId = 1}, //1
                new Comment {Id = 2, ItemId = 1}, //2
                new Comment {Id = 3, ItemId = 2}, //3
                new Comment {Id = 4, ItemId = 2}, //4
                new Comment {Id = 5, CommentId = 1}, //11
                new Comment {Id = 6, CommentId = 1}, //12
                new Comment {Id = 7, CommentId = 2}, //21
                new Comment {Id = 8, CommentId = 5}, //111
                new Comment {Id = 9, CommentId = 8}, //1111
                new Comment {Id = 10, CommentId = 9}, //11111
                new Comment {Id = 11, CommentId = 1}, //13
            };
        }

        [Test]
        public void GenerateTree()
        {
            var result = new List<CommentViewModel>
            {
                new CommentViewModel
                {
                    Id = 1, Comments = new List<CommentViewModel>
                    {
                        new CommentViewModel
                        {
                            Id = 5,
                            Comments = new List<CommentViewModel>
                            {
                                new CommentViewModel
                                {
                                    Id = 8, Comments = new List<CommentViewModel>
                                    {
                                        new CommentViewModel
                                        {
                                            Id = 9, Comments = new List<CommentViewModel>
                                            {
                                                new CommentViewModel {Id = 10}
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new CommentViewModel {Id = 6},
                        new CommentViewModel {Id = 11},
                    }
                },
                new CommentViewModel {Id = 2, Comments = new List<CommentViewModel> {new CommentViewModel {Id = 7}}},
                new CommentViewModel {Id = 3},
                new CommentViewModel {Id = 4},
            };

            var tree = DatabaseComments.GenerateTree();
            CollectionAssert.AreEqual(result, tree, new TestComparer());
        }

        [Test]
        public void GenerateTreeForParent()
        {
            var result = new List<CommentViewModel>
            {
                new CommentViewModel
                {
                    Id = 1, Comments = new List<CommentViewModel>
                    {
                        new CommentViewModel
                        {
                            Id = 5,
                            Comments = new List<CommentViewModel>
                            {
                                new CommentViewModel
                                {
                                    Id = 8, Comments = new List<CommentViewModel>
                                    {
                                        new CommentViewModel
                                        {
                                            Id = 9, Comments = new List<CommentViewModel>
                                            {
                                                new CommentViewModel {Id = 10}
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new CommentViewModel {Id = 6},
                        new CommentViewModel {Id = 11},
                    }
                }
            };

            var tree = DatabaseComments.GenerateTree(1);
            CollectionAssert.AreEqual(result, tree, new TestComparer());
        }

        [Test]
        public void GenerateTreeForItem()
        {
            var result = new List<CommentViewModel>
            {
                new CommentViewModel
                {
                    Id = 1, Comments = new List<CommentViewModel>
                    {
                        new CommentViewModel
                        {
                            Id = 5,
                            Comments = new List<CommentViewModel>
                            {
                                new CommentViewModel
                                {
                                    Id = 8, Comments = new List<CommentViewModel>
                                    {
                                        new CommentViewModel
                                        {
                                            Id = 9, Comments = new List<CommentViewModel>
                                            {
                                                new CommentViewModel {Id = 10}
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new CommentViewModel {Id = 6},
                        new CommentViewModel {Id = 11},
                    }
                },
                new CommentViewModel {Id = 2, Comments = new List<CommentViewModel> {new CommentViewModel {Id = 7}}}
            };

            var tree = DatabaseComments.GenerateTree(itemId: 1);
            CollectionAssert.AreEqual(result, tree, new TestComparer());
        }
    }

    internal class TestComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            var left = x as CommentViewModel;
            var right = y as CommentViewModel;

            if (left?.Comments != null && right?.Comments != null)
            {
                var leftArr = left.Comments.ToArray();
                var rightArr = right.Comments.ToArray();

                if (leftArr.Length != rightArr.Length) return 1;

                if (leftArr.Where((t, i) => Compare(t, rightArr[i]) != 0).Any())
                {
                    return 1;
                }
            }

            if (left?.Comments?.Any() == true && right?.Comments?.Any() != true) return 1;
            if (right?.Comments?.Any() == true && left?.Comments?.Any() != true) return 1;

            return left?.Id == right?.Id ? 0 : 1;
        }
    }
}