      program array

      integer i, sq(10)
      do 100 i = 1, 10
        sq(i) = i ** 2
        write (*,*) 'Array value sq(i) = ', sq(i)
100   continue


      stop
      end
