//using Contacts.Model;
//using Contacts.Repository;
//using Contacts.Service;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace Contacts.Tests
//{

//    [TestClass]
//    public class HackathonServiceTest
//    {

//        private IHackathonRepository _mockHackathonRepository;
//        private IIdeaRepository _mockIdeaRepository;
//        private HackathonService _hackathonService;
       
//        private List<Idea> _listIdea;
//        private List<Member> _members;


//        [TestInitialize]
//        public void HackathonServiceInitialize()
//        {
//            _members = new List<Member>
//            {
//                new Member{IdeaId=1,Name="saurabh"},
//                new Member{IdeaId=1,Name="shubham"}
//            };
//            List<Idea> lstIdea = new List<Idea>
//            {
//                new Idea{HackathonId=1,Id=1, Summary="abc",Details="qpew",TeamMembers=_members,Category=CategoryEnum.Domain,Likes=143 },
//                new Idea{HackathonId=1,Id=2, Summary="qwer",Details="iuwqeroi",TeamMembers=_members,Category=CategoryEnum.Domain,Likes=143},
//                new Idea{HackathonId=2,Id=1, Summary="qwer",Details="iuwqeroi",TeamMembers=_members,Category=CategoryEnum.Technology,Likes=143}
//            };
//            _listIdea = new List<Idea>
//            {
//                new Idea{HackathonId=1,Id=1, Summary="abc",Details="qpew",TeamMembers=_members,Category=CategoryEnum.Domain,Likes=143 },
//                new Idea{HackathonId=1,Id=2, Summary="qwer",Details="iuwqeroi",TeamMembers=_members,Category=CategoryEnum.Domain,Likes=143}
//            };

//            List<Hackathon> Hackathons = new List<Model.Hackathon>
//            {
//                new Hackathon{Id=1,EventName="bolt",MoOffice="pune",DateConducted=new DateTime(2019,02,02),Ideas=new List<Idea>()},
//                new Hackathon{Id=2,EventName="SIH",MoOffice="US",DateConducted=new DateTime(2019,03,02),Ideas=new List<Idea>() }
//            };
            
//            Mock<IHackathonRepository> _mockHackathonRepository = new Mock<IHackathonRepository>();
//            Mock<IIdeaRepository> _mockIdeaRepository = new Mock<IIdeaRepository>();

//            _mockHackathonRepository.Setup(mr => mr.Get()).Returns(() =>
//            {
//                foreach (var idea in lstIdea)
//                {
//                    foreach (var hackathon in Hackathons)
//                    {
//                        if (idea.HackathonId == hackathon.Id)
//                        { hackathon.Ideas.Add(idea); }
//                    }
//                }
//                return Hackathons;
//            }
//            );



//            _mockIdeaRepository.Setup(mr => mr.Get(It.IsAny<int>(), It.IsNotNull<CategoryEnum>())).Returns((int hackathonid, CategoryEnum category) =>
//            {
//                if (category == CategoryEnum.None)
//                {
//                    List<Idea> idealst = new List<Idea>();
//                    foreach (var idea in lstIdea) { if (idea.HackathonId == hackathonid) { idealst.Add(idea); } }
                   
//                    return idealst;

//                }
//                else
//                {
//                    List<Idea> idea = lstIdea.Where(x => x.Category == category).ToList();
//                    return idea;
//                }
//            });

//            _mockIdeaRepository.Setup(mr => mr.Add(It.IsAny<Idea>())).Returns((Idea idea) =>
//            {
                
//                    return 1;
//            });
//            _mockIdeaRepository.Setup(mr => mr.Edit(It.IsAny<Idea>())).Returns(IdeaStatusEnum.SUCCESS);
//            _mockIdeaRepository.Setup(mr => mr.Like(It.IsAny<int>())).Callback((int ideaId) => { var idea = _listIdea.Where(x => x.Id == ideaId).Single(); idea.Likes = idea.Likes + 1; });


            
       

//        this._mockHackathonRepository = _mockHackathonRepository.Object;
//            this._mockIdeaRepository = _mockIdeaRepository.Object;
//           _hackathonService = new HackathonService(this._mockHackathonRepository, this._mockIdeaRepository);




//        }



//        [TestMethod]
//        public void GetHackathons_WhenCalled_ShouldReturnCount2()
//        {
//            var returnHackathons = _hackathonService.GetHackathons();
            
//            Assert.AreEqual<int>(2,returnHackathons.Count());
            

//        }

//        [TestMethod]
//        public void GetIdea_WhenCalled_ShouldReturnHackathonName()
//        {
           
//            var returnIdeas = _hackathonService.GetIdea(1,CategoryEnum.None);
//            Assert.AreEqual<string>("bolt",returnIdeas.HackathonName.ToString());
//        }

//        [TestMethod]
//        public void GetIdea_WhenCalled_ShouldReturnsCount2()
//        {
            
//            var returnIdeas = _hackathonService.GetIdea(1,CategoryEnum.None);
           
            
//            Assert.AreEqual<int>(2, returnIdeas.Ideas.Count);
//        }

//        [TestMethod]
//        public void GetIdea_WhenCalled_ShouldReturnIdeasOfDomainCategory()
//        {
           
//            var returnIdeas = _hackathonService.GetIdea(1, CategoryEnum.Domain);


//            foreach (var idea in returnIdeas.Ideas)
//            {
//                Assert.AreEqual<string>("Domain", idea.Category.ToString());
//            }

//        }

//        [TestMethod]
//        public void AddIdea_WithCategoryParameterMissing_ShouldReturnIdeaId()
//        {
            
//            IdeaView idea = new IdeaView();
//            idea.Summary = "abc";
//            idea.Details = "weiu";
//            idea.Category = "Domain";
//            idea.TeamMembers = "Shubham,Navneet";
            

//            Assert.AreEqual(1,_hackathonService.AddIdea(idea, 1));
//        }

//        [TestMethod]
//        public void EditIdea_WhenCalled_ShouldReturnTrue()
//        {
//            IdeaView idea = new IdeaView();
//            idea.Summary = "abc";
//            idea.Details = "weiu";
//            idea.Category = "None";
//            idea.TeamMembers = "saurabh";

//            Assert.AreEqual(IdeaStatusEnum.SUCCESS,_hackathonService.EditIdea(idea));

//        }

//        [TestMethod]
//        public void LikeIdea_WhenCalled_ShouldIncrementLikesCountBy1()
//        {


//            _hackathonService.LikeIdea(1);
//            int likes = _listIdea[0].Likes;
//            Assert.AreEqual<int>(144,likes);
//        }
       
//    }
//}
