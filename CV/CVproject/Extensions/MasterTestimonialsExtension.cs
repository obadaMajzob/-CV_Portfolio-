using CVproject.Models;
using CVproject.ViewModels;

namespace CVproject.Extensions
{
    public static class MasterTestimonialsExtension
    {


        public static MasterTestimonialsViewModel ToViewModel(this MasterTestimonials MasterTestimonials)
        {

            return new MasterTestimonialsViewModel
            {
                Id = MasterTestimonials.Id,
                Name = MasterTestimonials.Name,
                bio = MasterTestimonials.bio,
                Position = MasterTestimonials.Position,
                ImageURL = MasterTestimonials.ImageURL,
               
                IsActivate = MasterTestimonials.IsActivate,
               

            };

        }

        public static MasterTestimonials ToModel(this MasterTestimonialsViewModel MasterTestimonialsVM)
        {

            return new MasterTestimonials
            {
                Id = MasterTestimonialsVM.Id,
                Name = MasterTestimonialsVM.Name,
                bio = MasterTestimonialsVM.bio,
                Position = MasterTestimonialsVM.Position,
                ImageURL = MasterTestimonialsVM.ImageURL,

                IsActivate = MasterTestimonialsVM.IsActivate,


            };

        }
        public static List<MasterTestimonialsViewModel> ToListViewModel(this List<MasterTestimonials> MasterTestimonials)
        {

            return MasterTestimonials.Select(x => x.ToViewModel()).ToList();

        }

        public static List<MasterTestimonials> ToListModel(this List<MasterTestimonialsViewModel> MasterTestimonialsVM)
        {

            return MasterTestimonialsVM.Select(x => x.ToModel()).ToList();

        }



    }
}
