      program matrix

      real a(2,2)
      integer i,j

!     We will only use the upper 3 by 3 part of this array

      do 20 j = 1,2
        do 10 i = 1, 2
          a(i,j) = i+j
10      continue
20    continue
      write (*,*) a


      stop
      end
