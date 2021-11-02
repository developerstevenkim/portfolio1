using System;
using System.Collections.Generic;
using Do4.Models;
using DohunKim.Models;

namespace DohunKim.Data
{
    public class SampleProject
    {
        public static List<Occupation> GetOccupations()
        {
            List<Occupation> Occupations = new List<Occupation>() {
                new Occupation {
                    OccupationTitle = "Student",
                    AuthorName = "Steven Dohun Kim",
                },
                new Occupation {
                    OccupationTitle = "Developer",
                    AuthorName = "Reina Jeongyeon Lee"
                }
            };
            return Occupations;
        }
        
        public static List<Author> GetAuthors()
        {
            List<Author> Authors = new List<Author>() {
                new Author {
                    AuthorName = "Steven Dohun Kim",
                    ProjectName = "TI Project"
                },
                new Author {
                    AuthorName = "Reina Jeongyeon Lee",
                    ProjectName = "uTrack"
                }
            };
            return Authors;
        }

        public static List<Project_Author> GetProject_Authors()
        {
            List<Project_Author> Project_Authors = new List<Project_Author>() {
                new Project_Author {
                    AuthorName = "Steven Dohun Kim",
                    ProjectName = "TI Project"
                },
                new Project_Author {
                    AuthorName = "Reina Jeongyeon Lee",
                    ProjectName = "uTrack"
                }
            };
            return Project_Authors;
        }


        public static List<Project_Language> GetProject_Languages()
        {
            List<Project_Language> Project_Languages = new List<Project_Language>() {
                new Project_Language {
                    LanguageName = "Python",
                    ProjectName = "TI Project"
                },
                new Project_Language {
                    LanguageName = "HTML",
                    ProjectName = "uTrack"
                }
            };
            return Project_Languages;
        }

        public static List<Language> GetLanguages()
        {
            List<Language> languages = new List<Language>() {
                new Language {
                    LanguageName = "HTML",
                    ProjectName = "uTrack"
                },
                new Language {
                    LanguageName = "CSS",
                    ProjectName = "uTrack"
                },
                new Language {
                    LanguageName = "JavaScript",
                    ProjectName = "uTrack"
                },
                new Language {
                    LanguageName = "Python",
                    ProjectName = "TI Project"
                },
                new Language {
                    LanguageName = "PHP",
                    ProjectName = "TI Project"
                },
                new Language {
                    LanguageName = "TypeScript",
                    ProjectName = "Mealo-Box"
                },
                new Language {
                    LanguageName = "React-Native",
                    ProjectName = "Mealo-Box"
                },
            };
            return languages;
        }

        public static List<ApplicationType> GetApplications()
        {
            List<ApplicationType> Applications = new List<ApplicationType>() {
                new ApplicationType {
                    TypeName = "Mobile Application"
                },
                new ApplicationType {
                    TypeName = "Web Application"
                },
                new ApplicationType {
                    TypeName = "RESTful API"
                },
                new ApplicationType {
                    TypeName = "iOS Application"
                },
                new ApplicationType {
                    TypeName = "Android Application"
                },
                new ApplicationType {
                    TypeName = "Chrome Extension"
                },
            };
            return Applications;
        }
        

        public static List<Project> GetProjects()
        {
            List<Project> Projects = new List<Project>() {
                new Project {
                    ProjectName = "uTrack",
                    TypeName = "Web Application",
                    ProjectDesc = "",
                    ReleaseDate = new System.DateTime(),
                    DemoURL = "",
                    GithubURL = ""
                },
                new Project {
                    ProjectName = "The Mindful Shopper",
                    TypeName = "Chrome Extension",
                    ProjectDesc = "",
                    ReleaseDate = new System.DateTime(),
                    DemoURL = "",
                    GithubURL = ""
                },
                new Project {
                    ProjectName = "TI Project",
                    ProjectDesc = "RESTful API",
                    ReleaseDate = new System.DateTime(),
                    DemoURL = "",
                    GithubURL = ""
                },
                new Project {
                    ProjectName = "Mealo-Box",
                    ProjectDesc = "Mobile Application",
                    ReleaseDate = new System.DateTime(),
                    DemoURL = "",
                    GithubURL = ""
                },
                
            };
            return Projects;
        }
    }
}