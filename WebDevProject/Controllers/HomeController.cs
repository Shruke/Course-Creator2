﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebDevProject.Controllers;
using WebDevProject.Models;
//using WebDevProject.ViewModels;
using Microsoft.Extensions.Configuration;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebDevProject.Controllers
{
    public class HomeController : Controller
    {
        private ModelContext _context;
        private IConfigurationRoot _config;

        public HomeController(ModelContext context, IConfigurationRoot config)
        {
            _context = context;
            _config = config;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var moduleInfo = from mod in _context.Module
                              select mod;

            IndexViewModel model = new IndexViewModel();

            Index index = _context.Index.SingleOrDefault();

            model.theIndex = index;

            if(moduleInfo != null)
            {
                model.Modules = (from module in moduleInfo
                                 select new Module()
                                 {
                                     moduleTitle = module.moduleTitle,
                                     Id = module.Id
                                 }).ToList();
            }

            //Right now this assumes there will only be one Index. In the case that more Indexes are ever added(for more classes),
            //then modify this search with "where reference.indexId == Id", where Id is passed in to this IActionResult.
            var referenceInfo = from reference in _context.IndexReferenceList
                                select reference;

            if(referenceInfo != null)
            {
                model.referenceList = (from reference in referenceInfo
                                       select new IndexReferenceList()
                                       {
                                           Link = reference.Link,
                                           Text = reference.Text
                                       }).ToList();
            }

            return View(model);
        }

        public IActionResult ModuleView(int Id)
        {
            var topicInfo = from top in _context.Topic
                            where top.ModuleId == Id
                            select top;

            ModuleViewModel model = new ModuleViewModel();

            Module module = _context.Module.SingleOrDefault(mod => mod.Id == Id);

            if (topicInfo != null)
            {
                model.Topics = (from top in topicInfo
                                 select new Topic()
                                 {
                                     topicTitle = top.topicTitle,
                                     Id = top.Id
                                 }).ToList();
            }

            model.theModule = module;

            var referenceInfo = from reference in _context.ModuleReferenceList
                                where reference.ModuleId == Id
                                select reference;

            if (referenceInfo != null)
            {
                model.referenceList = (from reference in referenceInfo
                                       select new ModuleReferenceList()
                                       {
                                           Link = reference.Link,
                                           Text = reference.Text
                                       }).ToList();
            }

            return View(model);
        }

        public IActionResult TopicView(int Id)
        {
            var questionInfo = from q in _context.Question
                               where q.TopicId == Id
                               select q;

            TopicViewModel model = new TopicViewModel();

            Topic topic = _context.Topic.SingleOrDefault(top => top.Id == Id);

            if (questionInfo != null)
            {
                model.Questions = (from q in questionInfo
                                   select new Question()
                                   {
                                       Id = q.Id,
                                       isMultipleChoice = q.isMultipleChoice,
                                       questionOrder = q.questionOrder
                                }).ToList();
            }

            model.theTopic = topic;

            var referenceInfo = from reference in _context.TopicReferenceList
                                where reference.TopicId == Id
                                select reference;

            if (referenceInfo != null)
            {
                model.referenceList = (from reference in referenceInfo
                                       select new TopicReferenceList()
                                       {
                                           Link = reference.Link,
                                           Text = reference.Text
                                       }).ToList();
            }

            return View(model);
        }

        public IActionResult MultipleChoiceView(int Id, int topicId)
        {
            MultipleChoiceViewModel model = new MultipleChoiceViewModel();

            Question question = _context.Question.SingleOrDefault(quest => quest.Id == Id);

            model.theQuestion = question;

            var questionInfo = from q in _context.Question
                               where q.TopicId == topicId
                               select q;

            var orderListLength = questionInfo.Count();
            model.orderListLength = orderListLength-1;
            
            if (questionInfo != null)
            {
                model.questionList = (from q in questionInfo
                                   select new Question()
                                   {
                                       Id = q.Id,
                                       isMultipleChoice = q.isMultipleChoice,
                                       TopicId = q.TopicId,
                                       questionOrder = q.questionOrder
                                   }).ToList();
            }

            var referenceInfo = from reference in _context.QuestionReferenceList
                                where reference.QuestionId == Id
                                select reference;

            if (referenceInfo != null)
            {
                model.referenceList = (from reference in referenceInfo
                                       select new QuestionReferenceList()
                                       {
                                           Link = reference.Link,
                                           Text = reference.Text
                                       }).ToList();
            }

            return View(model);
        }

        public IActionResult CodeQuestionView(int Id, int topicId)
        {
            CodeQuestionViewModel model = new CodeQuestionViewModel();

            Question question = _context.Question.SingleOrDefault(quest => quest.Id == Id);

            model.theQuestion = question;

            var questionInfo = from q in _context.Question
                               where q.TopicId == topicId
                               select q;

            var orderListLength = questionInfo.Count();
            model.orderListLength = orderListLength-1;

            if (questionInfo != null)
            {
                model.questionList = (from q in questionInfo
                                      select new Question()
                                      {
                                          Id = q.Id,
                                          isMultipleChoice = q.isMultipleChoice,
                                          TopicId = q.TopicId,
                                          questionOrder = q.questionOrder
                                      }).ToList();
            }

            var referenceInfo = from reference in _context.QuestionReferenceList
                                where reference.QuestionId == Id
                                select reference;

            if (referenceInfo != null)
            {
                model.referenceList = (from reference in referenceInfo
                                       select new QuestionReferenceList()
                                       {
                                           Link = reference.Link,
                                           Text = reference.Text
                                       }).ToList();
            }

            return View(model);
        }
    }
}
