using System.Text;
using CommentTrees.Models.View;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CommentTrees.Helpers
{
    public static class HtmlHelper
    {
        public static HtmlString PrintTree(this IHtmlHelper html, ItemViewModel item)
        {
            var sb = new StringBuilder();
            if (item.Comments != null)
                foreach (var comment in item.Comments)
                {
                    sb.PrintTreeNode(comment, item.Id);
                }

            return new HtmlString(sb.ToString());
        }

        private static void PrintTreeNode(this StringBuilder sb, CommentViewModel comment, int itemId)
        {
            sb.Append("<div style=\"margin-left: 10px; margin-top: 4px; margin-bottom:2px; padding:2px; border: 1px solid black;\">");
            sb.Append(comment.Id).Append(": ").Append(comment.Text);
            sb.Append("<a style=\"float: right;\" href=Delete/").Append(itemId).Append("/").Append(comment.Id).Append(">Delete</a>");
            sb.Append("<div style=\"margin: 3px;\">")
                .Append("<form method=\"post\" action=\"/Comment\">")
                .Append("<input type=\"hidden\" name=\"id\" value=\"").Append(comment.Id).Append("\" />")
                .Append("<input type=\"hidden\" name=\"itemId\" value=\"").Append(itemId).Append("\" />")
                .Append("<input type=\"text\" name=\"text\" />")
                .Append("<input type=\"submit\" value=\"Comment\" />")
                .Append("</form>")
                .Append("</div>");


            if (comment.Comments != null)
                foreach (var childComment in comment.Comments)
                {
                    sb.PrintTreeNode(childComment, itemId);
                }

            sb.Append("</div>");
        }
    }
}