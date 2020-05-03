  
$(window).load( function() {
  $('body').imagesLoaded( function() { 
    setTimeout(function() {
      $("#preloader").addClass("loaded");
    },2000);
  });

}); // window load end 
 
 $(document).ready( function() {
  window.onbeforeunload = function () {
    window.scrollTo(0, 0);
  }

function ajaxLoad() {
  PortfolioGrids();
  page_animation();
  full_menu();
  typed();
  scrollmove();
  cform();
  HoverVideo();
  carousel_slider();
  lightbox();
  hovertrid ();
  slider ();
}

function port_load() {
  PortfolioGrids();
  page_animation();
  typed();
  scrollmove();
  cform();
  HoverVideo();
  carousel_slider();
  lightbox();
  hovertrid ();
  slider ();
}

  ajaxLoad();


   // AJAX LOAD    
   $("main").on('click','[data-type="ajax-load"]', function(e) {
    $(".page-overlay").addClass("from-bottom");
    var href = $(this).attr("href");

    loadHtml();
    function loadHtml() {
        setTimeout(function() {
            loadContent(href);            
            history.pushState('', 'new URL: '+href, href);        
        },1000);
    }
    e.preventDefault();
    });
    window.onpopstate = function(event) {
        location.reload();
    };
    function loadContent(url) {
        var getData = $.get(url, function(response) {
            var markup = $("<main>" + response + "</main>");
            var fragment = markup.find("main").html();
            var title = markup.find("title").html();
            $('head title').html( title );

            $("main").html(fragment);
            ajaxLoad();
            window.scrollTo(0, 0);
            $(".page-overlay").addClass("from-bottom");
            setTimeout( function(){
              $(".page-overlay").addClass("from-bottom-end");
              setTimeout( function(){
                $(".page-overlay").removeClass("from-bottom");
                $(".page-overlay").removeClass("from-bottom-end");
              } , 800 );
            } , 500 );

        });
    }


//PORTFOLIO GRIDS
function PortfolioGrids() {
    var $container = $('.masonry');
    $container.imagesLoaded( function() {   
        $container.isotope({
          layoutMode: 'packery',
          itemSelector: '.grid-item',
          gutter:0,
          transitionDuration: "0.5s",
          columnWidth: '.grid-item'
        });
    })
        $('.portfolio_filter ul li a').on("click", function(){
          $(".portfolio_filter ul li a").removeClass("select-cat");
          $(this).addClass("select-cat");        
          var selector = $(this).attr('data-filter');
          $(".masonry").isotope({
              filter: selector,
              animationOptions: {
                  duration: 750,
                  easing: 'linear',
                  queue: false,
        }
      });
          return false;
      });   

      $(".filter-icon").on("click", function() {
        $('.portfolio_filter').addClass('show');  
        $('.portfolio').addClass('zendex');        
      });

      $(".portfolio_filter").on("click", function (event) {
        if (!$(event.target).is(".portfolio_filter ul li a")) {
                $('.portfolio_filter').removeClass('show');
                return false;
            }
        }); 
  
      // Infinite Scroll
      var curPage = 1;
      var pagesNum = $("#pagination-selector").find("li a:last").text();   // Number of pages
  
      $container.infinitescroll({
          itemSelector: '.grid-item',
          nextSelector: '.portfolio-pagination li a',
          navSelector: '#pagination-selector',
          extraScrollPx: 0,
          bufferPx: 0,
          maxPage: 6,
          loading: {
              finishedMsg: "No more works",
              msgText: '<div class="loader"><span></span></div>',
              speed: 'slow',
              selector: '.load-more',
          },
      },
      // trigger Masonry as a callback
      function( newElements ) {
  
            var $newElems = $( newElements );
            $newElems.imagesLoaded(function(){  // Append masonry        
              $newElems.animate({ opacity: 1 });
              $container.isotope( 'appended', $newElems, true ); 
            });
            // Check last page
            curPage++;
            if(curPage == pagesNum) {
              $( '.load-more button' ).remove();
            }
            $('.load-more').find('button').css('visibility', 'visible');
          });
  
          $container.infinitescroll( 'unbind' );
          // jQuery
      $container.on( 'append.infinitescroll', function( event, response, path, items ) {
        console.log( 'Loaded: ' + path );
      });
  
  
          $( '.load-more button' ).on('click', function() {
            setTimeout(function()
             { 
              port_load();   
              $('.grid-item').addClass('in-view'); 
              },1000);      
            $container.infinitescroll( 'retrieve' );
            $('.load-more').find('button').css('visibility', 'hidden');
            return false;
          });
    }


// MAGNIFIC POPUP    
  function lightbox() {
    $('.lightbox').magnificPopup({
          type:'image',
          gallery:{enabled:true},
          zoom:{enabled: true, duration: 300}
      });
  }


// OWL CAROUSEL JS  
function carousel_slider() {  
  var owlcar = $('.owl-carousel');
  if (owlcar.length) {
      owlcar.each(function () {
          var $owl = $(this);
          var itemsData = $owl.data('items');
          var autoplayData = $owl.data('autoplay');
          var autoPlayTimeoutData = $owl.data('autoplaytimeout');
          var dotsData = $owl.data('dots');
          var navData = $owl.data('nav');
          var marginData = $owl.data('margin');
          var stagePaddingData = $owl.data('stagepadding');
          var itemsDesktopData = $owl.data('items-desktop');
          var itemsTabletData = $owl.data('items-tablet');
          var itemsTabletSmallData = $owl.data('items-tablet-small');
          $owl.owlCarousel({
                items: itemsData
              , dots: dotsData
              , nav: navData
              , margin: marginData
              , loop: true
              , stagePadding: stagePaddingData
              , autoplay: autoplayData
              , autoplayTimeout: autoPlayTimeoutData
              , navText: ["<i class='fas fa-angle-left'></i>","<i class='fas fa-angle-right'></i>"]
              , responsive:{
                      0:{
                          items:itemsTabletSmallData,
                          stagePadding:0
                      },
                      600:{
                          items:itemsTabletData,
                          stagePadding:0
                      },
                      1000:{
                          items:itemsDesktopData
                      }
                  }
          , });
      });
  }

}


    //PAGE ANIMATION

    function page_animation() {

        tl1 = new TimelineMax({ease: Power2.easeOut});
        tl2 = new TimelineMax({paused:true});

        tl1.from('.team:nth-child(2)', 1,{ y: 30}, 2 )
            .from('.team:nth-child(3)', 1,{ y: 60}, 2  )

        tl2.to('.team:nth-child(2)', 1,{ y: 0}, .2  )
            .to('.team:nth-child(3)', 1,{ y: 0}, .2  )
      
          $(window).scroll( function(){
          var st = $(this).scrollTop();
          var sh = $('.hero').outerHeight();
          if( st < sh ){
            windowScroll = st/sh;
            if( windowScroll > 0 ){
              tl2.progress( windowScroll );
            }            
          }

          if ( st > 1 ){
            $('body').addClass('white');
          }else{
            $('body').removeClass('white');
          }


        }); // window scroll end


        $(".portfolio_filter ul li a").on("click", function(){
          $('html, body').animate({
              scrollTop: $(".portfolio").offset().top
          }, 500);
      });

  }

  // FULL MENU
  function full_menu() {
    $("header .nav-icon").on("click", function(){
      $('.full-menu').addClass('active');
      setTimeout(function(){ tl3.play(); tl4.play();  }, 400);
    });
  
    $(".full-menu .close-icon").on("click", function(){
      tl3.reverse(); tl4.reverse();
      setTimeout(function(){ $('.full-menu').removeClass('active'); }, 600);
    });
  
    // // Menu animation
    var menu = $(".full-menu .site-menu li");
        var tl3 = new TimelineMax({
          yoyo: false,
          reversed: true
        });
        tl3.staggerFrom(menu, .5, {
            x: "-50",
            opacity: 0
        },0.1);
  
        var tl4 = new TimelineMax({
          yoyo: false,
          reversed: true
        });
  
        tl4.staggerFrom('.right-content ul', .5, {
          x: "50",
          opacity: 0
      },0.1);
      
      $(window).scroll( function(){
      var scrlT = $(window).scrollTop();
      var total = $('.hero').height() + $('.portfolio').height();
      var scrlbtm =  scrlT + $('.hero').height();
      var pageh = $(document).height();
  
        if(scrlbtm > total){
          $('.portfolio_filter').addClass('stp');
        }else{
          $('.portfolio_filter').removeClass('stp');
        }
        
        if($(window).width() > 1025) {
          if(scrlbtm > pageh - 60){
            $('.uptotop, .say-hello, .open-search').addClass('stp');
          }else{
            $('.uptotop, .say-hello, .open-search').removeClass('stp');
          }
        }else{
          if(scrlbtm > pageh - 120){
            $('.uptotop, .filter-icon, .say-hello, .open-search').addClass('stp');
          }else{
            $('.uptotop, .filter-icon, .say-hello, .open-search').removeClass('stp');
          }
        }
      }); 
  }

  function HoverVideo(){
    $(".portfolio-item.video").on({
      mouseenter: function () {
          //stuff to do on mouse enter
        $('video', this).get(0).play(); 
      },
      mouseleave: function () {
          //stuff to do on mouse leave
        $('video', this).get(0).pause(); 
      }
  });
}

  // PORTFOLIO HOVER EFFECT
function hovertrid () {
  $(".grid-item").hover3d({
      selector: "figure",
      perspective: 3000,
      shine: false
  });
}


function scrollmove () { 
    $('.hero .down-arrow').on("click", function(){
      $('html, body').animate({
          scrollTop: $('.portfolio').offset().top - 30
      }, 800);
    }); 

    $('.uptotop').on("click", function(){
      $('html, body').animate({
          scrollTop: 0
      }, 800);
    }); 

    $('.open-search').on("click", function(){
      $('.search').addClass('open');
    }); 

    $('.sc-close').on("click", function(){
      $('.search').removeClass('open');
    }); 

    $(window).scroll( function(){
    
      setTimeout( function(){				
          
        var $animation_elements = $('.grid-item');
        var $window = $(window);
        
        function check_if_in_view() {
          var window_height = $window.height();
          var window_top_position = $window.scrollTop() + 50;
          var window_bottom_position = (window_top_position + window_height - 250);
        
          $.each($animation_elements, function() {
          var $element = $(this);
          var element_height = $element.outerHeight();
          var element_top_position = $element.offset().top;
          var element_bottom_position = (element_top_position + element_height);
        
        //check to see if this current container is within viewport
        if ((element_bottom_position >= window_top_position) && (element_top_position <= window_bottom_position)) {
            $element.addClass('in-view');
          }
        
        });
        }
      
        $window.on('scroll resize', check_if_in_view);
      } , 1000 );	
      
  }); 
}

//CONTACT FORM
function cform() {

  $("form .form-group input, form .form-group textarea").focus(function(){

    $(this).parents('.form-group').addClass('in');

    $('form .form-group input, form .form-group textarea').blur(function()
        {
            if( !$(this).val() ) {
                  $(this).parents('.form-group').removeClass('in');
            }
        });
  });
}

  
// HOME TYPED JS
function typed () {
  if ($('.element').length) {
    $('.element').each(function () {
        $(this).typed({
            strings: [$(this).data('text1'), $(this).data('text2')],
            loop: $(this).data('loop') ? $(this).data('loop') : false ,
            backDelay: $(this).data('backdelay') ? $(this).data('backdelay') : 2000 ,                
            typeSpeed: 10,
        });
    });
  }
}

 
//SLIDER
function slider () {
  $(".slider-images").vegas({
    slides: [
        { src: "img/slider-1.jpg" },
        { src: "img/slider-2.jpg" },
        { src: "img/slider-3.jpg" }
    ],
        animation: ['kenburnsUp', 'kenburnsDown', 'kenburnsLeft', 'kenburnsRight'],
        delay:5000,
        shuffle:true
    });
}

    

}); // document read end 



