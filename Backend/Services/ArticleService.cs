﻿using Backend.Dtos;
using ContainerToolDB;
using Newtonsoft.Json;

namespace Backend.Services;

public class ArticleService
{
    private readonly ContainerToolDBContext _db;

    public ArticleService(ContainerToolDBContext db) => _db = db;

    public List<Article> GetArticles()
    {
        return _db.Articles
            .ToList();
    }

    public List<Article> ArticlesForCsInquiryId(int id)
    {
        return _db.Articles.Where(x => x.CsinquiryId == id).ToList();
    }

    public Article PutArticle(ArticleDto articleDto)
    {
        var article = _db.Articles.Include(x => x.Csinquiry).Single(x => x.Id == articleDto.Id);
        article.IsFastLine = articleDto.IsFastLine;
        article.IsDirectLine = articleDto.IsDirectLine;
        article.ArticleNumber = articleDto.ArticleNumber;
        article.Pallets = articleDto.Pallets;
        _db.SaveChanges();

        return article;
    }

    public List<Article> RemoveArticlesForCsId(int id)
    {
        List<Article> removedArticles = new();
        foreach (Article currArticle in _db.Articles.Where(x => x.CsinquiryId == id).ToList())
        {
            removedArticles.Add(currArticle);
            _db.Articles.Remove(currArticle);
        }
        _db.SaveChanges();
        return removedArticles;
    }

    public Article RemoveArticle(int id)
    {
        try
        {
            var article = _db.Articles.Include(x => x.Csinquiry).Single(x => x.Id == id);
            _db.Articles.Remove(article);
            _db.SaveChanges();
            return article;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new Article();
        }
    }

    public Article EditArticle(EditArticleDto editArticleDto)
    {
        var article = _db.Articles.Single(x => x.Id == editArticleDto.Id);

        article.MinHeigthRequired = editArticleDto.MinHeigthRequired;
        article.DesiredDeliveryDate = editArticleDto.DesiredDeliveryDate;
        article.InquiryForFixedOrder = editArticleDto.InquiryForFixedOrder;
        article.InquiryForQuotation = editArticleDto.InquiryForQuotation;
        if (editArticleDto.AdditionalInformation != null)
        {
            article.AdditionalInformation = editArticleDto.AdditionalInformation;
        }

        _db.SaveChanges();
        return article;
    }

    public Article PostArticle(AddArticleDto articleDto)
    {
        var order = _db.Csinquiries.Single(x => x.Id == articleDto.CsInquiryId);

        var article = new Article
        {
            ArticleNumber = articleDto.ArticleNumber,
            IsDirectLine = articleDto.IsDirectLine,
            IsFastLine = articleDto.IsFastLine,
            CsinquiryId = articleDto.CsInquiryId,
            Pallets = articleDto.Pallets
        };

        _db.Articles.Add(article);
        _db.SaveChanges();

        return article;
    }
}
